        string path = Path.Combine(targetDirectory, applicationExecutableName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode node = xmlDoc.SelectSingleNode("configuration/configProtectedData/providers");
        node.InnerXml = string.Format("<add CertSubjectDistinguishedName=\"{0}\" CertStoreName=\"{1}\" name=\"X509ProtectedConfigProvider\" type=\"ProtectedConfigProvider.X509ProtectedConfigProvider, X509ProtectedConfigProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=098027505e2ed139\" />", certSubject, certStoreName);
        xmlDoc.Save(path);
