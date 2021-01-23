    /// <summary>
    /// Creates a GPRS Connection with the specified name.
    /// </summary>
    /// <param name="name">The name of the connection to create.</param>
    public void Start(string name)
    {
        string xml = "<wap-provisioningdoc>" +
                         "<characteristic type=\"CM_GPRSEntries\">" +
                             "<characteristic type=\"" + name + "\">" +
                                "<parm name=\"DestId\" value=\"{436EF144-B4FB-4863-A041-8F905A62C572}\" />" +
                                "<parm name=\"UserName\" value=\"\" />" +
                                "<parm name=\"Password\" value=\"\" />" +
                                "<parm name=\"Domain\" value=\"\" />" +
                                "<characteristic type=\"DevSpecificCellular\">" +
                                    "<parm name=\"GPRSInfoValid\" value=\"1\" />" +
                                    "<parm name=\"GPRSInfoAccessPointName\" value=\"internet.com\" />" +
                                "</characteristic>" +
                            "</characteristic>" +
                        "</characteristic>" +
                    "</wap-provisioningdoc>";
            XmlDocument configDoc = new XmlDocument();
            configDoc.LoadXml(xml);
            XmlDocument result = ConfigurationManager.ProcessConfiguration(configDoc, true);
        }
