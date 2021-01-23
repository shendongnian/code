    private class ClassBHolder
    {
        private readonly ClassB fixed;
        // Foo is the class which has the Initialize method
        private readonly Foo container;
        internal ClassBHolder(ClassB fixed, Foo container)
        {
            this.fixed = fixed;
            this.container = container;
        }
        internal void Execute(ClassA item)
        {
            container.InitializeStock(fixed, item);
        }
    }
    public void Initialize(ClassB fixed)
    {
        ClassBHolder holder = new ClassBHolder(fixed, this);
        Parallel.ForEach(itemCollection, holder.Execute);
    }
