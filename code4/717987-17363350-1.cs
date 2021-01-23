    static void Main()
    {
        var lines = ReadAllLines(@"path\to\your\file.txt");
        var lineNumbers = lines.Where(l => Criteria(l))
                               .Select((s, i) => i);
        foreach (var i in lineNumbers)
        {
            Console.WriteLine("Criteria met on line " + i);
        }
    }
    static bool Criteria(string s)
    {
        int i = int.Parse(Regex.Match(s, "(?<=Rows_affected: )\d+").Value);
    
        return i > 500;
    }
