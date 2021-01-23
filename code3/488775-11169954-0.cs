    using (var ctx = new MyContext())
    {
        var subscriptionToDelete = ctx.Subscriptions.Find(subscriptionToDeleteId);
        ctx.Users.Where(u => u.Subscription.Id == subscriptionToDeleteId).Load();
        ctx.Subscriptions.Remove(subscriptionToDelete);
        ctx.SaveChanges();
    }
