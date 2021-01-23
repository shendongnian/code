    public class HostFilter : FilterSkeleton
    {
        public string AllowedHostsNames { get; set; }
        private IList<string> HostNamesList
        {
            get
            {
                if (string.IsNullOrEmpty(AllowedHostsNames))
                    return new List<string>();
                return AllowedHostsNames
                    .Split(',')
                    .Select(n => n.ToUpper().Trim())
                    .ToList();
            }
        }
        public override FilterDecision Decide(LoggingEvent loggingEvent)
        {
            var names = HostNamesList;
            if (names.Contains(Environment.MachineName))
                return FilterDecision.Accept;
            return FilterDecision.Deny;
        }
    }
    <appender name="SomeAppender" type="log4net.Appender.SmtpAppender">
      <to value="" />
      <from value="" />
      <subject value="" />
      <smtpHost value="" />
      <authentication value="Basic" />
      <port value="25" />
      <username value="" />
      <password value="" />
      <bufferSize value="10" />
      <lossy value="false" />
      <layout type="log4net.Layout.PatternLayout">
         <conversionPattern value="%newline%date [%thread] %-5level %logger - %message%newline%newline%newline" />
      </layout>
      <filter type="Logging.HostFilter, AssemblyName">
        <allowedHostsNames value="host1, host2, host3" />
      </filter>
    </appender>
