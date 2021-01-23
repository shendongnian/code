    public string[] GetData()
    {
       string[] data = args.Trim().Split(',');
        List<string> returnData = new List<string>();
            // Loop over strings
        foreach (string s in data)
        {
            if(s == "true"){
               returnData.Add("1");
            }
            else if(s == "false"){
                returnData.Add("0");
            }
            else
                returnData.Add(s);
        }
        return returnData.ToArray();
     }
