    public int LineCounter()
    {
        StreamReader myRead = new StreamReader(@"C:\TestFiles\test.txt");
        int lineCount = 0;
        
        while (!myRead.EndOfStream)
        {
           string line = myRead.ReadLine();
           if (!string.IsNullOrWhiteSpace(line))
             lineCount++;
        }
    
        myRead.Close();
        
        return lineCount;
    }
