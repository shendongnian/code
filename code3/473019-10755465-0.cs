    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    namespace SampleWinSvc
    {
      static class Program
      {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
    #if (!DEBUG)
          ServiceBase[] ServicesToRun;
          ServicesToRun = new ServiceBase[] { new Service1() };
          ServiceBase.Run(ServicesToRun);
    #else
          //Debug code: this allows the process to run 
          // as a non-service. It will kick off the
          // service start point, and then run the 
          // sleep loop below.
          Service1 service = new Service1();
          service.Start();
          // Break execution and set done to true to run Stop()
          bool done = false;
          while (!done)
            Thread.Sleep(10000);
          service.Stop();
    #endif
        }
      }
    }
