    public object[] GetData()
    {
       string[] data = args.Trim().Split(',');
        List<object> returnData = new List<object>();
            // Loop over strings
        foreach (string s in data)
        {
            if(s == "true"){
               returnData.Add(1);
            }
            else if(s == "false"){
                returnData.Add(0);
            }
            else
                returnData.Add(s);
        }
        return returnData.ToArray();
     }
