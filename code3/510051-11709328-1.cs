    using (var context = new MyEntities())
    {
        context.Attach(client);
        client.Name = "Bob";
        context.SaveChanges();
    }
