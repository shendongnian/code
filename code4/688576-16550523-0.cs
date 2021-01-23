    using (var conn = new EntityConnection(connectionString))
    {
        conn.Open();
        using (var db = new InventoryContext(conn))
        {
            db.Products.ToList();
            conn.State.Dump();
            db.SaveChanges();
            conn.State.Dump();
        }
    }
