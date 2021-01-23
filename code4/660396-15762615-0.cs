    public static List<List<GlobalClasses.ValueDateSummary>> GetValueDateSummary()    
    {
        var allLists = new List<List<GlobalClasses.ValueDateSummary>>();
     
        foreach (DataRow row in dtValueDateSummary.Rows)
        {
            objSummary = new GlobalClasses.ValueDateSummary();
            objSummary.fld1= row["1"].ToString();
            objSummary.fld2 = row["2"].ToString();
            objSummary.fld3 = row["3"].ToString();
            objSummary.fld5 = row["4"].ToString();
    
            drList.Add(objSummary);
        }   
        allLists.Add(drList);
        
        //add other lists to allLists
        //..
        return allLists;
    }
