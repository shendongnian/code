    public static List() SearchFaucets(string mId, string mCode)
    {
        var dataConnect = new PxLinqSqlDataContext();
        return (from f in dataConnect.GetTable<TblFaucets>()
            where (f.Mfr == Convert.ToInt32(mId))
            where (f.Code == mCode)
            select new {                              // create anonymous object 
                      ID = f.ID,                      // only holding the data you want to
                      Manufacturer = Manufacturer.Name,  // assuming there is property Name within your manufacturer table?!
                      Code = f.Code,
                      Description = f.Description,
                      Price = f.Price,
                      Date = f.Date
                   }).ToList();
    }
