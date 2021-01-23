    public abstract class ReactiveObjectConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : ReactiveObject
    {
        protected ReactiveObjectConfiguration()
        {
            Ignore(e => e.Changed);
            Ignore(e => e.Changing);
            Ignore(e => e.ThrowExceptions);
        }
    }
    public class YourEntityConfiguration : ReactiveObjectConfiguration<YourEntity>
    {
        public YourEntityConfiguration()
        {
            // Your extra configurations
        }
    }
    
