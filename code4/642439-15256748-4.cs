        foreach (var i in LocalItemList)
        {
            dbContext.Containers.Attach(i.Container);
            dbContext.Items.Add(i);
        }
        dbContext.SaveChanges();
