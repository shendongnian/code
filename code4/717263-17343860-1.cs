    [WebMethod]
    public string[] insertNewRecord(string prefix)
    {
             string status = "";
             List<string> d = new List<string>();
             try
             {
               // logic code for insertion if success set msg
                 status = "New record inserted";
             }
             catch (Exception ac)
             {
                 status = " Error occurs";
             }
             d.Add(string.Format("{0}", status));
             return d.ToArray();
     }
