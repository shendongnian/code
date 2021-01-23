    public void GetData(out List<string> strings, out List<Int16> shorts)
    {
       string[] data = args.Trim().Split(',');
       strings= new List<string>();
       shorts = new List<Int16>();
            // Loop over strings
        foreach (string s in data)
        {
            if(s == "true"){
               shorts.Add(1);
            }
            else if(s == "false"){
                shorts.Add(0);
            }
            else
                returnData.Add(s);
        }
     }
