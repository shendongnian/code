    using (StreamReader sr = new StreamReader(@"C:\Users\Username\Documents\a.txt"))
    using (StreamWriter sw = new StreamWriter(@"C:\Users\Username\Documents\b.txt"))
    {
        string line = String.Empty;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("="))
            {
               sw.WriteLine(line);
            }
        }
    }
