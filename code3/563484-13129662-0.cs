    class Foo
    {
        [ImportingConstructor]
        public Foo(IController myController,
                   [Import("RepositoryX")] IRepository repository)
        {
            myController.Repository = repository;
        }
    }
