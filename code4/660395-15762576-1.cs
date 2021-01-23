    [WebMethod]
    [ScriptMethod]
    public static List<GlobalClasses.ValueDateSummary>  GetValueDateSummary()
    {
        // your db logic
        Wrapper wrapper = new Wrapper();
        
        List<GlobalClasses.ValueDateSummary> drList = new List<GlobalClasses.ValueDateSummary>();
        foreach (DataRow row in dtValueDateSummary.Rows)
        {
            objSummary = new GlobalClasses.ValueDateSummary();
            objSummary.fld1= row["1"].ToString();
            objSummary.fld2 = row["2"].ToString();
            objSummary.fld3 = row["3"].ToString();
            objSummary.fld5 = row["4"].ToString();
    
            drList.Add(objSummary);
        }
        wrapper.list1 =  drList;
        //similarly fetch other lists 
        //wrapper.list2 = drList2;
        return new JavaScriptSerializer().Serialize(wrapper);
    }
