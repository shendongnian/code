        public static IAppender FindAppenderByName(string name)
        {
        	ILoggerRepository rootRep = LogManager.GetRepository();
        	foreach (IAppender iApp in rootRep.GetAppenders())
        	{
        		if (string.Compare(name, iApp.Name, true) == 0)
        		{
        			return iApp;
        		}
        	}
        	return null;
        }
        
        private void SetupSmtpAppender()
        {
        	IAppender appender = FindAppenderByName("Global.SmtpAppender");
        	SmtpAppender smtpAppender = (SmtpAppender)appender;
            smtpAppender.From = "me@domain.com";
        	smtpAppender.Subject = "My subject";
        	smtpAppender.SmtpHost = "smtp@mydomain.com";
    ... setup more properties
        }
