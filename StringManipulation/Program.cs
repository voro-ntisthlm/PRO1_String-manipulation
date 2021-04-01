using System;
using System.Collections.Generic;
using System.Linq;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Starter string from the assignment.
            string[] highScores = {"LENA 100000", "MICKE 23004", "MARTIN 2000"};
            
            List<string[]> splitScores = SplitScores(highScores);          

            bool isRunning = true;
            while (isRunning)
            {                
                WriteScores(splitScores);
                splitScores = inputHandler(splitScores);
                
            }

            Console.ReadLine();
        }

        static List<string[]> inputHandler(List<string[]> parsedList){
            Console.Write(
                "==============================================================\n"+
                " Enter Name     (All characters allowed): "
            );

            string inputName = Console.ReadLine();

            Console.Write(
                " Enter new socore (Only numbers allowed): "
            );

            string inputScore = Console.ReadLine();

            if(Int32.TryParse(inputScore, out int newScore)){
                List<string[]> entryScore = EnterScore(newScore, inputName, parsedList);
                
                // Debug code
                foreach (var item in entryScore)
                {
                    Console.WriteLine(item[0]);
                }
                Console.ReadKey();
                return entryScore;
            }
            else
            {
                Console.Write(" No No, that is not a number, press [enter] to try again... ");
                Console.ReadLine();
                return parsedList;
            }

        }
        
        static List<string[]> EnterScore(int newScore, string name, List<string[]> list){
            try
            {
                Console.WriteLine("DADAWD");
                var oldScore = list.FirstOrDefault(item => item.Contains(name.ToUpper()));
                Console.WriteLine(oldScore[0]);
                if (name.ToUpper() ==  oldScore[0])
                {
                    Console.WriteLine("DAWDAW");
                    string[] entry = {name.ToUpper(), newScore.ToString()};

                    list.Remove(oldScore);
                    list.Add(entry);
                    return list;
                }
                else{
                    
                    string[] entry = {name.ToUpper(), newScore.ToString()};
                    Console.WriteLine("DDD");
                    list.Add(entry);
                    Console.WriteLine("AAA");

                    return list;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Whoops, something went wrong when trying to add the entry, try restarting the program if the issue persists.");
                return list;   
            }
        }

        // Split each 
        static List<string[]> SplitScores(string[] scores){

            List<string[]> tempScores = new List<string[]>();  

            // Loop through the heigh scores, split them and add them to a list of seperated or split heigh scores.
            foreach (var score in scores)
            {
                string[] splitScore = score.Split(" ");
                tempScores.Add(splitScore);
            }

            return tempScores;
        }

        static void WriteScores(List<string[]> list){
            Console.Clear();
            Console.WriteLine(@"
 _   _  _         _       _____                               
| | | |(_)       | |     /  ___|                              
| |_| | _   __ _ | |__   \ `--.   ___   ___   _ __   ___  ___ 
|  _  || | / _` || '_ \   `--. \ / __| / _ \ | '__| / _ \/ __|
| | | || || (_| || | | | /\__/ /| (__ | (_) || |   |  __/\__ \
\_| |_/|_| \__, ||_| |_| \____/  \___| \___/ |_|    \___||___/
            __/ |                                             
           |___/                                              
==============================================================");

            foreach (var item in list)
            {
                Console.WriteLine(" " + item[0] + " has " + item[1] + " points.");
            }
        }
    }
}
