    public class Module : IHttpModule
    {
        private static bool isStarted = false;
        private static object syncRoot = new object();
    
        public void Dispose()
        {
            //clean-up code here.
        }
    
        public void Init(HttpApplication context)
        {
            if (!isStarted)
            {
                lock (syncRoot)
                {
                    if (!isStarted) 
                    {
                        //PROCESS ON APPLICATION START EVENT
                        this.OnApplicationStart(context);
                        isStarted = true;
                    }
                }
            }
        }
    
        public void OnApplicationStart(HttpApplication context)
        {
            //DO SOMETHING
        }
    }
