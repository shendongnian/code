    public static Dictionary<string, StringBuilder> FASTAFileReadIn(string file)
    {
        var seq = new Dictionary<string, StringBuilder>();
        var regName = new Regex("^>(\\S+)", RegexOptions.Compiled);
        var regAppend = new Regex("\\S+", RegexOptions.Compiled);
        Match tempMatch = null;
        string currentName = string.Empty;
        try
        {
            using (StreamReader sReader = new StreamReader(file))
            {
                string line = string.Empty;
                while ((line = sReader.ReadLine()) != null)
                {
                    if ((tempMatch = regName.Match(line)).Success)
                    {
                        if (!seq.ContainsKey(tempMatch.Groups[1].Value))
                        {
                            currentName = tempMatch.Groups[1].Value;
                            seq.Add(currentName, new StringBuilder());
                        }
                    }
                    else if ((tempMatch = regAppend.Match(line)).Success && currentName != string.Empty)
                    {
                        seq[currentName].Append(tempMatch.Value);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(e.ToString());
        }
        return seq;
    }
