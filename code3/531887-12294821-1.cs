    protected void Application_Start()
    {
       //Other stuff
       ModelBinders.Binders.Add(typeof(double?), new NullableDoubleModelBinder());
    }
