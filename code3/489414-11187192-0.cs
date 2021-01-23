    public interface IApplicationPhysicalPathProvider
    {
        string ApplicationPhysicalPath { get; }
    }
    public class AspNetApplicationPhysicalPathProvider
    {
        public string ApplicationPhysicalPath 
        {
            get { return HostingEnvironment.ApplicationPhysicalPath; }
        }
    }
