    public class CustomClass
    {
        public int Id { get; set; }
        public int OtherId { get; set;}
        public DateTime Date { get; set; }
    }
    
    public void DoStuff()
    {        
        // approx 800,000 items
        List<CustomClass> allItems = _repo.GetCustomClassItemsFromDatabase();
        var index1 = new Dictionary <int, CustomClass>; 
        foreach (OtherCustomClass foo1 in allItems)
        {
            List<CustomClass> allOtherIDs ;
            allOtherIDs=null;
            if (!index1.TryGetValue(foo1.OtherID,allOtherIDs))
             {
                allOtherIDs=new List<CustomClass>;
                index1.add(foo1.OtherID,allOtherIDs);
            }
            allOtherIDs(foo1.OtherID)=foo1;
        }
        foreach (OtherCustomClass foo in _bar)
        {
            // original linq-to-entities query,
            // get most recent Ids that apply to OtherId
            List<CustomClass> filteredItems = (
                from item in allOtherIDs(foo.OtherID)
                where item.Date <= foo.Date
                group item by item.Id into groupItems
                select groupItems.OrderByDescending(i => i.Date).First()).ToList();
    
            DoOtherStuff(filteredItems);
        }
    }
