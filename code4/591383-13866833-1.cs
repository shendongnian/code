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
