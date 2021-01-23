    IProvider providerX = GetProviderFromConfig();
    IHandler handlerZ = GetHandlerFromConfig();
    IPreProcessor preProcessorY = GetProcessorFromConfig();
    var provider = 
        new ProviderWrapper(providerX, preProcessorY, handlerZ);
    private static IProvider GetProviderFromConfig()
    {
        if (ConfigurationManager.AppSettings["provider"] == "mail")
        {
             return new MailProvider();
        }
        else
        {
             return new FtpProvider();
        }
    }
    // implement GetHandlerFromConfig  just like
    // the GetProvider.
