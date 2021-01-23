    public string getNextItemCode()
    {
        dc = new StockDataClassesDataContext();
        var nextNumber = 
            (from tbItem in dc.tblItems
             select tbItem.ItemCode)
            .AsEnumerable()
            .Select(code => Convert.ToInt32(code.Substring(code.IndexOf("-") + 1))
            .DefaultIfEmpty()
            .Max();
        return "IT-" + nextNumber;
    }
