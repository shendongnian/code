    public List<DataRow> QualifyPercent(string status, string selectQualifier)
    {
       var matchList = status.Split(" ".ToCharArray());
    
       var dataList = 
           fbTab.Select(selectQualifier).Select(row => 
             matchList.Select(
                m => m.ToString().ToLower() == row["Word"].ToSring().ToLower()).Any());
    
           return dataList;
    }
