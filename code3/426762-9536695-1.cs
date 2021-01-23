    public override void OnGetValue(LocationInterceptionArgs args)
        {
            args.ProceedGetValue();
            if (args.Value() == null)
            {
                args.Value = LongOperation();
                args.ProceedSetValue();
            }
            
        } 
