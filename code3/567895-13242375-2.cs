    using System;
    using System.IO;
    
    class WordCounter
    {
    static void Main()
    {
          string inFileName = null;
    
          Console.WriteLine("Enter the name of the file to process:");
          inFileName = Console.ReadLine();
    
          StreamReader sr = new StreamReader(inFileName);
    
          int counter = 0;
          string delim = " ,."; //maybe some more delimiters like ?! and so on
          string[] fields = null;
          string line = null;
    
          while(!sr.EndOfStream)
          {
             line = sr.ReadLine();//each time you read a line you should split it into the words
             line.Trim();
             fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
             counter+=fields.Length; //and just add how many of them there is
          }
    
    
          sr.Close();
          Console.WriteLine("The word count is {0}", counter);
    }
} 
