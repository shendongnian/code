    private static readonly object _lock = new object
    public static void Queue(Item item)
    {
        try
        {
            Monitor.Enter(_lock);
            var db = new MyDataContext();
            item.Time = DateTime.Now;
            db.Items.InsertOnSubmit(item);
            db.SubmitChanges();
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }
    public static Item TryDequeue()
    {
        try
        {
            Monitor.Enter(_lock);
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
        finally
        {
            Monitor.Exit(_lock);
        }
    }
