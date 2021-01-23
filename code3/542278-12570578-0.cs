    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace test{
    
        public class App {
        
            public static void Main(string[] args) {
                var myDictionary = new Dictionary<KeyValuePair<int,int>, string>(); 
    
                Console.WriteLine("Adding 2 items...");
                myDictionary.Add(new KeyValuePair<int,int>(3, 3), "FirstItem"); 
                myDictionary.Add(new KeyValuePair<int,int>(5, 5), "SecondItem"); 
                Console.WriteLine("Dictionary items: {0}", myDictionary.Count);
                
                Console.WriteLine("Adding 2 duplicate items...");
                myDictionary.Add(new KeyValuePair<int,int>(3, 3), "FirstItem"); 
                myDictionary.Add(new KeyValuePair<int,int>(5, 5), "SecondItem"); 
                Console.WriteLine("Dictionary items: {0}", myDictionary.Count);
            }
        }
    }
