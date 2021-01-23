    public abstract class WebResourceBase : ResourceBase
    {
        private ResourceBase localPath;
        public ResourceBase LocalPath
        {
            get { return localPath; }
            set
            {
                if (value.GetType() != GetType())
                {
                    throw new Exception("Naughty");
                }
                localPath = value;
            }
        }        
        private ResourceBase ftpPath;
        public ResourceBase FtpPath
        {
            get { return ftpPath; }
            set
            {
                if (value.GetType() != GetType())
                {
                    throw new Exception("Naughty");
                }
                ftpPath = value;
            }
        }
    }
