    using(reader = new StreamReader("date.txt"))
    {
        String line;
        while ((line = sr.ReadLine()) != null)
        {
             Console.WriteLine(line);
        }
    }
