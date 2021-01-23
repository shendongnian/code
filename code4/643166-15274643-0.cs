    private static void AssociateAndSave(int oId, int cId)
    {
        using (var context = new ModelEntities())
        {
            var owner = (from o in context.Owners
                            select o).FirstOrDefault(o => o.ID == oId);
            var child = (from o in context.Children
                            select o).FirstOrDefault(c => c.ID == cId);
            owner.Children.Add(child);
            context.Attach(owner);
            context.SaveChanges();
        }
    }
