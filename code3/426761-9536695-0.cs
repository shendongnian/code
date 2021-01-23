    public override void OnGetValue(LocationInterceptionArgs args)
        {
            args.ProceedGetValue();
            if (args.Value() == null)
            {
                object obj = ObjectFactory
                                .GetInstance(args.Location.PropertyInfo.PropertyType);
                args.Value = obj;   
                args.ProceedSetValue();
            }
            
        } 
