    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Web.Administration;
    namespace MSWebAdmin_Application
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServerManager serverManager = new ServerManager();
                Site site = serverManager.Sites["Default Web Site"];
                // get the app for this site
                var appName = site.Applications[0].ApplicationPoolName;
                ApplicationPool appPool = serverManager.ApplicationPools[appName];
            
                Console.WriteLine("Site state is : {0}", site.State);
                Console.WriteLine("App '{0}' state is : {1}", appName, appPool.State);
                if (appPool.State == ObjectState.Stopped)
                {
                    // do something because the web site is "suspended"
                }
            }
        }
    }
