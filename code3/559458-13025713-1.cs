     public List<Items> GetItems(int[] ids)
        {
        var a = from Items in db.item 
        where ids.Contains(Items.id)
        select new Items
        {
        
        }
            return a.ToList();
        }
