    public abstract class ResourceBase<T> 
        where T : ResourceBase<T>
    { }
    
    public abstract class WebResourceBase<T> : ResourceBase<T>
        where T : ResourceBase<T>
    {
        public T LocalPath { get; set; }
        public T FtpPath { get; set; }
    }
    
    public class JavaScript : WebResourceBase<JavaScript> 
    { 
    }
