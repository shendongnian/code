        foreach (var i in LocalItemList)
        {
            i.Container.Items = null;
            
            var attachedContainer = dbContext.Containers.Local.SingleOrDefault(c =>
                c.keyPart1 == i.Container.keyPart1 &&
                c.keyPart2 == i.Container.keyPart2);
            if (attachedContainer != null)
                i.Container = attachedContainer;
            else
                dbContext.Containers.Attach(i.Container);
                // or dbContext.Containers.Add(i.Container);
                // depending on if you want to insert the Container or not
            dbContext.Items.Add(i);
        }
        dbContext.SaveChanges();
