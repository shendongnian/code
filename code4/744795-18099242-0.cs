    internal class Config
        {
            private readonly Lazy<Rootpdf> _config;
            public Config()
            {
                _config = new Lazy<Rootpdf>(ReadConfiguration);
            }
    
            private Rootpdf ReadConfiguration()
            {
                throw new NotImplementedException();
            }
    
            
            public Rootpdf pdfConfiguration
            {
                get
                {                
                    try
                    {
                        return _config.Value;
                    }
                    catch (Exception e)
                    {
                        Log.Error("An error occurred while reading the configuration file.", e);
                    }
    
                    return null;
                }
            }
