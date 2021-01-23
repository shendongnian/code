    using (StreamReader sr = new StreamReader("TestFile.txt"))
    {
        // Note that we're not doing anything in here
    }
    {
         String line = sr.ReadToEnd();
         Console.WriteLine(line);
    }
