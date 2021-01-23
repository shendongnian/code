    public static IEnumerable<string> ReadLines(string filename)
    {
        using (TextReader tr = new StreamReader(filename))
        {
            string nextLine = tr.ReadLine();
    
            while (nextLine != null)
            {
                yield return nextLine;
                nextLine = tr.ReadLine();
            }
        }
    }
