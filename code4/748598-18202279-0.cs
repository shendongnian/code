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
    // a is the value of a in the file.
    int a = Int32.Parse(values["a"].ToString());
