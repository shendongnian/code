    List<Device> devices = new List<Device>(loaded.Descendants("Device")
                                                 .Select(e =>
                                                   new Device(e.Element("username").Value,
                                                              e.Element("AgentName").Value,
                                                              e.Element("password").Value,
                                                              e.Element("domain").Value
                                                             )));
