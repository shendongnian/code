    var item = new Item { ItemName = "Default1", };
    db.SomeEntities.Add(new SomeEntity { DefaultItem = item, Items = new[]
    {
        item,
        new Item{ ItemName = "Item1", },
        new Item{ ItemName = "Item2", },
        new Item{ ItemName = "Item3", },
        new Item{ ItemName = "Item4", },
    }
    });
    db.SaveChanges();
