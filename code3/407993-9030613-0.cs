    public interface ILogProvider : IDisposable
    {
        void Open();
    }
    public class LogService : ILogProvider
    {
        private readonly ServiceHost host;
        public LogService(ServiceHost host)
        {
            this.host = host;
        }
                     
        public void Open()
        {
            // Open Service
        }
        public void Dispose()
        {
            host.Dispose();
        }
    }
    public class ServiceHost : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ServiceHost()
        {
            Dispose(false);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //do managed cleanup
            }
            
            // do unmanaged cleanup here            
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var host = new ServiceHost();
            using (LogService log = new LogService(host))
            {
                host.Dispose();
            }
        }
    }
