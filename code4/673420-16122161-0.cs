    static class WordList
    {
       static List<string> words = new List<string>();
       public static  void ListOfWords()
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
       public static List<string> GetWords()
       {
          return words;
       }
       public static void AddWord(string value)
       {
           words.Add(value);
       }
    }
