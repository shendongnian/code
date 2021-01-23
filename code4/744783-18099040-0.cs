        private static Rootpdf  _pdfConfiguration ;
        public static Rootpdf pdfConfiguration
        {
            get
            {
                try
                {
                    if (_pdfConfiguration == null)
                    {
                        //retrieve the configuration file.
                        //load the configuration and return it!
                    }
                    else
                    {
                        return _pdfConfiguration;
                    }
                }
                catch (Exception e)
                {
                    Log.Error("An error occurred while reading the configuration file.", e);
                }
    
                return _pdfConfiguration;
            }
        }
