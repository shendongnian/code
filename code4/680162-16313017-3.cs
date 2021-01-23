    public string getNextItemCode()
    {
        dc = new StockDataClassesDataContext();
        var nextNumber = 
            (from tbItem in dc.tblItems
             let c = tbItem.ItemCode
             select Convert.ToInt32(c.Substring(c.IndexOf("-") + 1))
            .DefaultIfEmpty()
            .Max();
        return "IT-" + nextNumber;
    }
