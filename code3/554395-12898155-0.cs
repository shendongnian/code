        public static void ChangeRemoteAddress(System.Net.IPAddress remoteAddressIp)
        {
            var hier = log4net.LogManager.GetRepository() as Hierarchy;
            if (hier == null)
            {
                Console.WriteLine("Unable to change Syslog filename, null hierarchy");
                return;
            }
            var sysLogAppender =
                (SyslogAppender)hier.GetAppenders().
                                          First(appender => appender.Name.Equals("UdpAppender",
                                              StringComparison.InvariantCultureIgnoreCase));
            if (null == sysLogAppender)
            {
                Console.WriteLine("Unable to change Syslog filename, appender not found");
                return;
            }
            sysLogAppender.RemoteAddress = remoteAddressIp;
            sysLogAppender.ActivateOptions();
        }
