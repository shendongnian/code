    private Object dequeueLock = new Object();
    public static Item TryDequeue()
    {
        lock (dequeueLock)
        {
            try
            {
                var db = new MyDataContext();
    
                var item = db.Items
                    .Where(x => x.Status == 0)
                    .OrderBy(x => x.Time)
                    .FirstOrDefault();
    
                if (item == null)
                    return null;
    
                item.Status += 1;
    
                db.SubmitChanges();
    
                return item;
            }
            catch (ChangeConflictException)
            {
                return null;
            }
        }
    }
