    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace RemoteMonitor
    {
        class Server
        {
            public void StartServer(RemoteMonitor cRemoteMonitor)
            {
                cRemoteMonitor.WriteLog("Thread started!");
            }
        }
    }
