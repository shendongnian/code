        public Listener()
        {
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
        }
        public void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            WriteException(e.Exception);
        }
        public void WriteException(Exception e)
        {
            string app_identity = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name;
            string server_name = System.Environment.MachineName;
            using (LogServerEntities context = new LogServerEntities())
            {
                LOG log = new LOG();
                log.DATE = DateTime.Now;
                log.THREAD = Thread.CurrentThread.Name;
                log.MESSAGE = e.Message;
                log.LOGGER = string.Format("{0} {1}", app_identity, server_name);
                log.LEVEL = Level.Exception.ToString();
                log.EXCEPTION = e.GetType().FullName;
                var web_exception = e as WebException;
                if (web_exception != null)
                {
                    if (web_exception.Status == WebExceptionStatus.ProtocolError)
                    {
                        var response = web_exception.Response as HttpWebResponse;
                        if (response != null)
                            log.HTTP_RESPONSE_CODE = ((int)response.StatusCode).ToString();
                        else
                            log.HTTP_STATUS = web_exception.Status.ToString();
                    }
                    else
                    {
                        log.HTTP_STATUS = web_exception.Status.ToString();
                    }
                }
                context.LOGs.Add(log);
                context.SaveChanges();
            }
        }
