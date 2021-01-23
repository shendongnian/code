    private Context context = new Context();
    private GenericRepository<IFoo> FooRepo;
    public GenericRepository<IFoo> Article
    {
        get
        {
            if (this.FooRepo == null)
            {
                this.FooRepo = new GenericRepository<IFoo>(context);
            }
            return FooRepo;
        }
    }
