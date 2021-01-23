    using (StreamReader sr = new StreamReader("TestFile.txt"));
    {
         String line = sr.ReadToEnd();
         Console.WriteLine(line);
    }
