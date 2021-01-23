    static Dictionary<Type, TypeEnum> Types = new Dictionary<Type, TypeEnum>() { { typeof(TypeA), TypeEnum.TypeA } }; // Fill with more key-value pairs
    
    enum TypeEnum
    {
        TypeA
        // Fill with types
    }
    public static void Log<T>(T log)
    {
        TypeEnum type;
        if (Types.TryGetValue(typeof(T), out type)) {
            switch (type)
            { ... }
        }
    }
