    public abstract class ResourceBase
    { }
    
    public abstract class WebResourceBase
    {
        public ResourceBase LocalPath { get; private set; }
        public ResourceBase FtpPath { get; private set; }
        protected abstract ResourceBase ParseLocalPath(string s);
        protected abstract ResourceBase ParseFtpPath(string s);
    }
    
    public class JavaScript : WebResourceBase<JavaScript> 
    { 
        protected override ResourceBase ParseLocalPath(string s)
        {
            // etc.
        } 
        protected override ResourceBase ParseFtpPath(string s)
        {
            // etc.
        } 
    }
