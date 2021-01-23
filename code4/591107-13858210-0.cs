    string xml = FormXml(licenceNo: "1",machineIP:"1.2.3.4",generalInfo:"some Info");
---
    public string FormXml(
        string generalInfo="N/A",
        string licenceNo="N/A",
        string userID="N/A",
        string maxUser="N/A",
        string maxMachine="N/A",
        string machineIP="N/A",
        string machineMAC="N/A")
    {
        return new XElement("LICENSE",
                    new XElement("GENERAL_INFO", generalInfo),
                    new XElement("LICENSE_INFO",
                            new XElement("LICENSE_NO", licenceNo),
                            new XElement("USER_ID", userID)),
                    new XElement("LICENCE_CONSTRAINT",
                            new XElement("MAX_USER", maxUser),
                            new XElement("MAX_MACHINE", maxMachine)),
                    new XElement("MACHINE_INFO",
                            new XElement("MACHINE_IP", machineIP),
                            new XElement("MACHINE_MAC", machineMAC))).ToString();
    }
