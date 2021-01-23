    public static void RegisterBinders(ModelBinderDictionary binders)
    {
       binders.Add(typeof(MyModel), new MyModelBinder());
       // other binders
    }
