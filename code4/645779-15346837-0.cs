    using (var context = new MyContext())
    {
        var askToDelete = context.Asks.Single(a => a.Id == askToDeleteId);
        var relatedMessageAsks = context.MessageAsks
            .Where(m => m.Ask.Id == askToDeleteId)
            .ToList();
        // or just: context.MessageAsks.Where(m => m.Ask.Id == askToDeleteId).Load();
        context.Asks.Remove(askToDelete);
        // or DeleteObject if you use ObjectContext
        context.SaveChanges();
    }
