    public class SomeRepository<TContext, T> where TContext : DbContext where T : class, new()
    {
        public virtual void Create(T item) { }
    }
    internal class SomeCrud : SomeRepository<SomeContext, Product>
    {
        public override void Create(Product item) { }
    }
