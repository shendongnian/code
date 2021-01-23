      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(vls.NameTable);
      namespaceManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
      namespaceManager.AddNamespace("default", "http://URLHere/webservices/");
      XmlNode payLoadNode =
        vls.SelectSingleNode("/soap:Envelope/soap:Body/default:GetValueListForFieldResponse/default:GetValueListForFieldResult", namespaceManager);
      string encodedXml = payLoadNode.InnerText;
