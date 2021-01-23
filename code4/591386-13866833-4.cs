    public interface IGenericRepository<out T> {}
    public class GenericRepository<T> : IGenericRepository<T> { }
    private Context context = new Context();
    private IGenericRepository<IFoo> FooRepo;
    public IGenericRepository<IFoo> Article
    {
        get
        {
            if (this.FooRepo == null)
            {
                this.FooRepo = new GenericRepository<Foo>(context);
            }
            return FooRepo;
        }
    }
