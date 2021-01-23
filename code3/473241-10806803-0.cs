    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using IndexLoader;
    using System.Threading;
    
    namespace myNameSpace
    {
        public partial class LoaderService : ServiceBase
        {
            Thread newThread;
            public LoaderService()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
             
                Loader loader = new Loader();
    
                ThreadStart threadDelegate = new ThreadStart(loader.StartProcess);
                newThread = new Thread(threadDelegate);
                newThread.Start();
    
            }
    
            protected override void OnStop()
            {
                if ((newThread != null) && (newThread.IsAlive))
                {
     
                    
                    Thread.Sleep(5000);
                    newThread.Abort();
    
                }
            }
        }
    }
