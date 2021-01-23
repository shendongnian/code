    static void Main(string[] args)
    {
        var types = Assembly.GetExecutingAssembly().Modules
            .SelectMany(m => m.GetTypes())
            .Where(t =>
                t.GetMethod("GetAll") != null &&
                t.GetMethod("SaveAll") != null &&
                t.GetMethod("GetAll").ReturnType.IsGenericType)
            .Select(t =>
                new
                {
                    RepositoryType = t,
                    ReturnTypeArgument = 
                        t.GetMethod("GetAll").ReturnType.GenericTypeArguments[0]
                }
                )
            .ToList();
        (new List<dynamic> { new A(), new B() }).ToList().ForEach(chosenType =>
        {
            var association = types
                .FirstOrDefault(t => 
                    t.ReturnTypeArgument == chosenType.GetType());
            if (association == null)
                return;
            var repType = association.RepositoryType;
            dynamic list = repType.GetMethod("GetAll")
                .Invoke(chosenType, new object[] { });
            repType.GetMethod("SaveAll")
                .Invoke(chosenType, new object[] { list });
        });
    }
