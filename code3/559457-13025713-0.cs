     public List<Items> GetItems(int[] ids)
        {
        var a = from Items in db.item 
        where ids.Contains(items.id)
        select new Items
        {
        
        }
            return a.ToList();
        }
