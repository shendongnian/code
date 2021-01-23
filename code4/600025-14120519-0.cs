    public Item FindByID(Session session, Guid itemID)
    {
        using (var tr = session.BeginTransaction())
        {
            return session.Get<Item>(itemID);
        }
    }
    
    public void RemoveItem(Session session, Item item)
    {
        using (var tr = session.BeginTransaction())
        {
             session.Delete(item);
             tr.Commit();
        }
    }
