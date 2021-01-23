    public List<DataRow> Percent(string status, DataRow[] rows)
    {
        List<DataRow> dataList = new List<DataRow>();
        var wordPattern = new Regex(@"\w+");
                
        foreach (Match match in wordPattern.Matches(status)) {
            foreach (var item in rows) {
                if (item["Word"].ToString().ToLower() == match.ToString().ToLower()) {
                    dataList.Add(item);
                }
            }
        }
    
        return dataList;
    }
