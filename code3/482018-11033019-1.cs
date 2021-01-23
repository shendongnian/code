    public interface IEntity
    {
        string Id { get; set; }
    }
    public partial class MyEntity: IEntity
    {
    }
    public partial class MyEntities
    {
        public override int SaveChanges(System.Data.Objects.SaveOptions options)
        {
            var generator = new IdGenerator();
            foreach(var entry in this.ObjectStateManager.GetObjectStateEntries(EntityState.Added))
            {
                var entity = entry.Entity as IEntity;
                if (entity != null)
                {
                    entity.Id = generator.CreateNewId();
                }
            }
            return base.SaveChanges(options);
        }
    }
