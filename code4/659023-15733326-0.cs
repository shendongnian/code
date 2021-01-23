        protected override void OnStart(string[] args)
        {
            try
            {
                this.RequestAdditionalTime(30000);
                ServiceStart = DateTime.Now;
                XmlConfigurator.Configure();
                log4net.ThreadContext.Properties["EventID"] = 666;
                log.Info("Service Started");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Service Configuration:");
                log.Info(sb.ToString());
                Timer t = new Timer(new TimerCallback(SendMail));
                t.Change(TimeSpan.Zero, TimeSpan.FromMinutes(every));
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error starting service: {0}", ex.ToString());
            }
        }
