    private static void AddAttachment(string Attachment)
    {
    	if (!string.IsNullOrEmpty(Attachment))
    	{
    		if (File.Exists(Attachment))
    		{
    			foreach (IAppender Appender in Log.log.Logger.Repository.GetAppenders())
    			{
    				if (Appender.GetType().ToString().IndexOf(".SmtpCustomAppender") != -1)
    				{
    					((SmtpCustomAppender)(Appender)).Attachment = Attachment;
    				}
    			}
    		}
    		else
    		{
    			VPLog.Log4Net.LogWarning(string.Format("Le fichier {0} est introuvable sur le disque, il sera ignoré.", Attachment));
    		}
    	}
    }
