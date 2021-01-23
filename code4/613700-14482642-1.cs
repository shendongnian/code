    public void CreatXmlConfigurationFileIfNotFoundWithDefultTags(string path)
    {
        if (!File.Exists(path))
        {
            try
            {
                var setting = new XElement("Settings",
                    new XElement("UseStreemCodec", new XAttribute("value", "false")),
                    new XElement("SipPort", new XAttribute("value", "5060")),
                    new XElement("H323Port", new XAttribute("value", "1720"))
                  );
                var config = new XElement("Configuration", setting,
                    new XElement("IncomingCallsConfiguration"),
                    new XElement("OutGoingCallsConfiguration")));
                config.Save(path); // save XElement to file
            }
            catch (Exception e)
            {
                Trace.WriteLineIf(Logger.logSwitch.TraceError, e.Message);
            }
        }
    }
