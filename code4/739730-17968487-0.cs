    public class TempTable
    {
        public int ID {get;set;}
        public int? ParentID {get;set;}
        public String Name {get;set;}
        public int SortOrder {get;set;}
    }
    public List<TempTable> GetTempData()
    {
        var temp = new List<TempTable>();
        temp.Add(new TempTable { ID = 1, ParentID = null, Name = "Test 1", SortOrder = 1 });
        temp.Add(new TempTable { ID = 2, ParentID = 1, Name = "Test 2", SortOrder = 1 });
        temp.Add(new TempTable { ID = 3, ParentID = 1, Name = "Test 3", SortOrder = 3 });
        temp.Add(new TempTable { ID = 4, ParentID = 2, Name = "Test 4", SortOrder = 1 });
        temp.Add(new TempTable { ID = 5, ParentID = 1, Name = "Test 5", SortOrder = 2 });
        return temp;
    }
