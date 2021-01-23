    public List<Person> ParseFile(string filePath)
    {
        List<Person> lp = new List<Person>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            while (!sr.EndOfStream)
            {
                lp.Add(new Person(sr.ReadLine()));
            }
        }
        return lp;
    }
