    using (MCT_DB_ArchiveEntities ent = new MCT_DB_ArchiveEntities())
    using (var transaction = ent.Database.BeginTransaction())
    {
        var item = new User {Id = 418, Name = "Abrahadabra" };
        ent.IdentityItems.Add(item);
        ent.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items ON;");
        ent.SaveChanges();
        ent.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[User] OFF");
        transaction.Commit();
    }
