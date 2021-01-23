    protected override void InitializeModules()
    {
        try
        {
            base.InitializeModules();
        }
        catch (ModuleInitializeException e)
        {
            Exception innerException = e.InnerException;
    
            // Handle Exception
        }
    }
