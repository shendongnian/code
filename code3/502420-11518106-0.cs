    static void Main(string[] args)
    {
          List<string[]> allLines = new List<string[]>();
         TextReader tr = new StreamReader("Data.txt");
         string word = tr.ReadLine();
         // write a line of text to the file
         while ( word !=  null ) {
    
             //now split this line into words
             string[] val = word.Split(new Char[] { ',' });
             
             //Add this line into allLines
             allLines.Add(val);
             //Now read the next line
             word = tr.ReadLine();
         }
    }
