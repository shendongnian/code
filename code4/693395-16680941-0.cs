    string[] lines = File.ReadAllLines("MyCsvFile");
    Dictionary<string, double> parsedCsv = new Dictionary<string,double>();
    
    // Read the first line
    string col1 = "", col2 = "";
    if(lines.Length > 0)
    {
        string[] tokens = lines.Split(',');
        col1 = tokens[1];
        col2 = tokens[2];
    }
    
    for(int i = 1; i < lines.length; i++)
    {
        string[] tokens = lines.Split(',');
        string varName1 = tokens[0] + "." + col1;
        string varName2 = tokens[0] + "." + col2;
        double value = double.Parse(tokens[1]);
        parsedCsv.Add(varName1, value);
        value = double.Parse(tokens[2]);
        parsedCsv.Add(varname2, value);
    }
