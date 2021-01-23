    using System.IO;
    using System.Text;
    using log4net.Core;
    using log4net.Layout;
    using log4net.Util;
    using log4net.Appender;
    namespace CsvLogging
    {
        public class HeaderOnceAppender : RollingFileAppender 
        {
            protected override void WriteHeader()
            {
                try
                {
                    if (LockingModel.AcquireLock().Length == 0)
                    {
                        base.WriteHeader();
                    }
                }
                finally
                {
                    LockingModel.ReleaseLock();
                }
            }
        }
    }
