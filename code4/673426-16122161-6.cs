    static class WordList
    {
        static string filePath = @"C:\temp\Word.txt";
        static List<string> words = new List<string>();
        private static void CheckFile()
        {
           //Makes sure our base words are saved to the file
           if (!File.Exists(@"C:\temp\Word.txt"))
           {
               using (TextWriter writer = new StreamWriter(filePath))
               {
                   writer.WriteLine("test");
                   writer.WriteLine("dog");
                   writer.WriteLine("shit");
               }
           }
       }
       public static  void ListOfWords()
       {
           CheckFile();
           words.Clear();
           using (TextReader file = new StreamReader(filePath))
           {
               char[] delineators = new char[] { '\r', '\n' };
               string[] tempWords = file.ReadToEnd().Split(delineators, StringSplitOptions.RemoveEmptyEntries);
               foreach (string line in tempWords)
               {
                   words.Add(line);
               }
           }
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
           CheckFile();
           using (TextWriter writer = new StreamWriter(filePath,true ))
           {
               writer.WriteLine(value);
           }
       }
    }
