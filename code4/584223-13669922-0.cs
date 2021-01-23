    [TestMethod]
    public void TestIQueryableWithList()
    {
        int ID1 = 1;
        List<int> IDs = new List<int> { 1, 3, 4, 8 };
        using (var db = new SellooEntities())            
        {
            var iq = db.tblSearches.Where(x => IDs.Contains(x.seaUserId);
        }             
    }
