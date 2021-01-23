            RollingFileAppender fileAppender = LogManager.GetRepository()
                            .GetAppenders().FirstOrDefault(appender => appender is RollingFileAppender) as RollingFileAppender;
          
            if (fileAppender != null && File.Exists(((RollingFileAppender)fileAppender).File))
            {
                string path = ((RollingFileAppender)fileAppender).File;
                log4net.Appender.FileAppender curAppender = fileAppender as log4net.Appender.FileAppender;
                curAppender.File = path;
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.Create);
                }
                catch(Exception ex)
                {
                    (log4net.LogManager.GetLogger(this.GetType())).Error("Could not clear the file log", ex);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
