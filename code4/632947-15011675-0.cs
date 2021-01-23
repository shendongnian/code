    class CdineWithTrigger : CreateDatabaseIfNotExists<RepositoryContext>
    {
       protected override void Seed(RepositoryContext context)
       {
          context.Database.ExecuteSqlCommand("YOUR SQL CORE FOR ADDING A TRIGGER");
       }
    }
