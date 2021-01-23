    XNamespace ns = "http://schemas.microsoft.com/online/managementsystems/topologydefinition/2009/11";
    foreach (var machine in XElement.Load(@"c:\mydata.xml").Descendants(ns + "Machine"))
    {
        string name = machine.Attribute("Name").Value;
        string vmHost = machine.Attribute("VmHost").Value;
    
        XElement ipBinding = machine.Descendants(ns + "IPBinding").Single();
        string vnType = ipBinding.Attribute("VirtualNetworkType").Value;
        string ip = ipBinding.Attribute("IP").Value;
    }
