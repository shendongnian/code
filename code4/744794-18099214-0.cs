    public class RootPdf
    {
        private static RootPdf instance;
        private RootPdf()
        {
            //retrieve the configuration file.
            //load the configuration and return it! 
        }
        public static RootPdf Instance
        {
            get
            {
                if (instance == null)
                {
                    try
                    {
                        instance = new RootPdf();
                    }
                    catch (Exception e)
                    {
                        Log.Error("An error occurred while reading the configuration file.", e);
                        return null;
                    }
                }
                return instance;
            }
        }
    }
