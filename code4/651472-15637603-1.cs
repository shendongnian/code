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
                string fileName = @"C:\Your.log";
                using (StreamWriter sw = new StreamWriter(File.Exists(fileName) ? System.IO.File.Open(fileName, FileMode.Append) : System.IO.File.Create(fileName), Encoding.UTF8))
                {
                    Byte[] logMessage = new UTF8Encoding(true).GetBytes(message);
                    sw.Write(logMessage,0,logMessage.Length);
                }
            }
        }
    }
