    private List<Match> find_emails_matches()
    {
        List<Match> result = new List<Match>();
        using (FileStream stream = new FileStream(@"C:\tmp\test.txt", FileMode.Open, FileAccess.Read))
        {
            using(StreamReader reader = new StreamReader(stream))
            {
                string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                Regex regex = new Regex(pattern, RegexOptions.None | RegexOptions.Compiled);
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    if (line.Contains('@'))
                    {
                        MatchCollection matches = regex.Matches(line); // Here is where it takes time                            
                        foreach(Match m in matches) result.Add(m);
                    }
                }
            }
        }
        return result;
    }
