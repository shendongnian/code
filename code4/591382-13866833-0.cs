    public interface IGenericRepository<out T> {}
    public class GenericRepository<out T> : IGenericRepository<T> { }
    private Context context = new Context();
    private IGenericRepository<IFoo> FooRepo;
    public IGenericRepository<IFoo> Article
    {
        get
        {
            if (this.FooRepo == null)
            {
                this.FooRepo = new GenericRepository<Foo>();
            }
            return FooRepo;
        }
    }
