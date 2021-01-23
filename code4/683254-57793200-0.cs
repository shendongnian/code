      private static void InstanceLogger()
        {
            if (logger == null)
                logger = LogManager.GetLogger(typeof(Utility));
            // Code to troubleshoot Log4Net issues through Event log viewer
            StringBuilder sb = new StringBuilder();
            foreach (log4net.Util.LogLog m in logger.Logger.Repository.ConfigurationMessages)
            {
                sb.AppendLine(m.Message);
            }
            throw new Exception("String messages: " + sb.ToString());
        }
