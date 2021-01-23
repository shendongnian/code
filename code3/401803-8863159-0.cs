    using (StreamReader sr = new StreamReader(@"test.txt"))
    {
           string line;
           while ( (line = sr.ReadLine()) != null) 
           {
               Console.WriteLine(line);
           }
    }
