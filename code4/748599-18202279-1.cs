    string[] lines = File.ReadAllLines("path to file");
    Hashtable values = new Hashtable();
    foreach (string line in lines)
    {
        if (line.Contains("=\""))
        {
            string[] split = line.Split('=');
            values.Add(split[0], split[1].Replace("\"",""));
        }
    }
    // GeneratedNumber is the value of GeneratedNumber in the file.
    int GeneratedNumber = Int32.Parse(values["GeneratedNumber"].ToString());
