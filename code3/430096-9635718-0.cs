    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Diagnostics;
    
    namespace SerivicioBIOHAcademico
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main()
            {
                try
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] 
    			    { 
    				    new BIOHAcad() 
    			    };
                    ServiceBase.Run(ServicesToRun);
                }
                catch(Exception ex)
                {
                    string SourceName = "WindowsService.ExceptionLog";
                    if (!EventLog.SourceExists(SourceName))
                    {
                        EventLog.CreateEventSource(SourceName, "Application");
                    }
    
                    EventLog eventLog = new EventLog();
                    eventLog.Source = SourceName;
                    string message = string.Format("Exception: {0} \n\nStack: {1}", ex.Message, ex.StackTrace);
                    eventLog.WriteEntry(message, EventLogEntryType.Error);
                }
            }
        }
    }
