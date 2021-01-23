    using System;
    using System.Collections.Generic;
    
    class WordList
    {
        private List<string> words = new List<string>();
        public void ListOfWords()
        {
            words.Add("test");         // Contains: test
            words.Add("dog");          // Contains: test, dog
            words.Insert(1, "shit"); // Contains: test, shit, dog
    
            words.Sort();
            foreach (string word in words) // Display for verification
            {
                Console.WriteLine(word);
                
            }
            
        }
        
        public void AddWord(string value){
            words.Add(value);
          }
    }
