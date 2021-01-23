    public interface ICreatedOn
    {
        public DateTime CreatedOn { get; set; }
    }
    public partial class MyEntity : ICreatedOn
    {
    }
    public static TEntity AsNew<TEntity>(this TEntity entity) where TEntity : ICreatedOn
    {
        if(entity != null)
            entity.CreatedOn = DateTime.Now;
        return entity;
    }
    using(var context = new YourContext()) 
    {
        context.MyEntities.Add(new MyEntity().AsNew())
    }   
