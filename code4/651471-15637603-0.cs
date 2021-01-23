    using System;
    using System.Text;
    using System.Diagnostics;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    
    namespace YourNamespace
    {
        [ConfigurationElementType(typeof(CustomTraceListenerData))]
        class UTF8Logging:CustomTraceListener
        {
            public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
            {
                if (data is LogEntry && this.Formatter != null)
                {
                    this.WriteLine(this.Formatter.Format(data as LogEntry));
                }
                else
                {
                    this.WriteLine(data.ToString());
                }
            }
    
            public override void Write(string message)
            {
                this.WriteLine(message);
            }
    
            public override void WriteLine(string message)
            {
                using (System.IO.FileStream fs = System.IO.File.Create(@"C:\Your.log"))
                {
                    Byte[] logMessage = new UTF8Encoding(true).GetBytes(message);
                    fs.Write(logMessage,0,logMessage.Length);
                }
            }
        }
    }
