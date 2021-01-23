    public abstract class ResourceBase 
    { }
    
    public abstract class WebResourceBase<T> : ResourceBase
        where T : WebResourceBase<T>
    {
        public T LocalPath { get; set; }
        public T FtpPath { get; set; }
    }
    
    public class JavaScript : WebResourceBase<JavaScript> 
    { 
    }
