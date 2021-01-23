    public string MyPath1;
    public string MyPath2;
    public void ReadConfig(string txtFile)
    {
        using (StreamReader sr = new StreamReader(txtFile))
        {
            // Declare the dictionary outside the loop:
            var dict = new Dictionary<string, string>();
            // (This loop reads every line until EOF or the first blank line.)
            string line;
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
                // Split each line around '=':
                var tmp = line.Split(new[] { '=' }, 
                                     StringSplitOptions.RemoveEmptyEntries);
                // Add the key-value pair to the dictionary:
                dict[tmp[0]] = dict[tmp[1]];
            }
            // Assign the values that you need:
            MyPath1 = dict["MyPathOne"];
            MyPath2 = dict["MyPathTwo"];
        }
    }
