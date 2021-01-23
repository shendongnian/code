    void MultipleInserts(List<int> values)
    {
        using (var db = new DBDataContext())
        {
            foreach (var value in values)
            {
                // look in db first
                var dbItem = db.Items
                        .Where(x => x.Value == value)
                        .SingleOrDefault();
    
                if (dbItem == null)
                {
                    // look in ChangeSet second
                    var cachedItem = db.GetChangeSet().Inserts
                        .OfType<Item>()
                        .Where(x => x.Value == value)
                        .SingleOrDefault();
                    
                    if (cachedItem == null)
                    {
                        var Item = new Item()
                        {
                            Value = value
                        };
                        db.Items.InsertOnSubmit(Item);
                    }
                }
            }
            db.SubmitChanges();
        }
    }
