    XmlDocument doc = new XmlDocument();
    doc.Load(path);
    
    var nm = new XmlNamespaceManager(doc.NameTable);
    nm.AddNamespace("jb", "urn:jboss:domain:1.2");
    
    foreach (XmlNode selectNode in doc.SelectNodes("jb:server/jb:system-properties/jb:property", nm))
    {
        if (selectNode.Attributes["name"].Value == "teststudio.pwd")  // tsuser1
        {
            selectNode.Attributes["value"].Value = "new password";  // changes password value for "FTP_USER".
        }
        if (selectNode.Attributes["name"].Value == "watson.git_pwd")   //github
        {
            selectNode.Attributes["value"].Value = "new passwordx";  // changes password value for "FTP_READ_USER".
        }
        if (selectNode.Attributes["name"].Value == "FTP_READ_PASS")   // wtsntro
        {
            selectNode.Attributes["value"].Value = "new_passwordy";  // changes password value for "FTP_PASSWORD".
        }
    }
    
    doc.Save(path);  // Save changes.
    Console.WriteLine("Password changed successfully");
