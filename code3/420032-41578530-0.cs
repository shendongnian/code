    using System;
    using System.Collections.Generic;
    
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                String[] crew = {"Spock", "Kirk", "Bones", "Picard", "Uhura", "Chekov"};
                HashSet<String> linkedHashSet = new HashSet<String>(crew);
    
                // Show order is preserved
                foreach(String value in linkedHashSet){
                    Console.Write(value); Console.Write(" ");
                }
    
                // Remove from the middle
                linkedHashSet.Remove("Picard");
                Console.WriteLine();
                foreach(String value in linkedHashSet){
                    Console.Write(value); Console.Write(" ");
                }
    
                // Add it back but it is back in the middle not the end
                linkedHashSet.Add("Picard");
                Console.WriteLine();
                foreach(String value in linkedHashSet){
                    Console.Write(value); Console.Write(" ");
                }
    
                // Remove and trim then add
                linkedHashSet.Remove("Picard");
                linkedHashSet.TrimExcess();
                linkedHashSet.Add("Picard");
                Console.WriteLine();
                foreach(String value in linkedHashSet){
                    Console.Write(value); Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
