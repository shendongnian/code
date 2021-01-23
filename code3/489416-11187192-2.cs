    public interface IApplicationPhysicalPathProvider
    {
        string ApplicationPhysicalPath { get; }
    }
    public class AspNetApplicationPhysicalPathProvider : IApplicationPhysicalPathProvider
    {
        public string ApplicationPhysicalPath 
        {
            get { return HostingEnvironment.ApplicationPhysicalPath; }
        }
    }
