    // The using statement also closes the StreamReader.
    using(var sr = new StreamReader("date.txt"))
    {
        String line;
        while ((line = sr.ReadLine()) != null)
        {
             Console.WriteLine(line);
        }
    }
