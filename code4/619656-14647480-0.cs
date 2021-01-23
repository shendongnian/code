            var xmlDataEntAddAttr = @"<?xml version=""1.0""?>
                            <ADDITIONALINFO>
                            <Host> Test Host Name </Host>
                            <IPAddress>Test IP Address</IPAddress>
                            <Domain>Test Domain</Domain>
                            <HostMethod>Test Host Method</HostMethod>
                            <Flag>Test Flag</Flag>
                      </ADDITIONALINFO>";
            var xDocument = XDocument.Parse(xmlDataEntAddAttr);
            if (xDocument.Root != null)
            {
                var coll = xDocument.Root.Elements().Select(x => new {Name = x.Name, Value = x.Value});
                foreach (var item in coll)
                {
                  Console.WriteLine("Name: {0}\tValue: {1}", item.Name, item.Value);
                }
            }
            Console.ReadLine();
