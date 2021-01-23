    public string MyPath1;
    public string MyPath2;
    public void ReadConfig(string txtFile)
    {
        using (StreamReader sr = new StreamReader(txtFile))
        {
            //The dictionary needs to be out of the loop
            var dict = new Dictionary<string, string>();
            string line;
            //With this loop, you already get all the lines
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
                //Split each line by '='
                var tmp = line.Split(new[] { '=' }, 
                                     StringSplitOptions.RemoveEmptyEntries);
                //Add each key-value pair to the dictionary
                dict[tmp[0]] = dict[tmp[1]];
            }
            //Make the assignments you need
            MyPath1 = dict["MyPathOne"];
            MyPath2 = dict["MyPathTwo"];
        }
    }
