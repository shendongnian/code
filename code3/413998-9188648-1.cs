    XmlDocument xmlDoc=new XmlDocument();
     
    xmlDoc.Load("F:/Documents and Settings/Administrator/Desktop/Account.xml");
     
    XmlElement subRoot=xmlDoc.CreateElement("User");
    //UserName
    XmlElement appendedElementUsername=xmlDoc.CreateElement("UserName");
    XmlText xmlTextUserName=xmlDoc.CreateTextNode(txtUsrName.Text.Trim());
    appendedElementUsername.AppendChild(xmlTextUserName);
    subRoot.AppendChild(appendedElementUsername);
    xmlDoc.DocumentElement.AppendChild(subRoot);
    //Email
     
    XmlElement appendedElementEmail=xmlDoc.CreateElement("Email");
    XmlText xmlTextEmail=xmlDoc.CreateTextNode(txtEmail.Text.Trim());
    appendedElementEmail.AppendChild(xmlTextEmail);
    subRoot.AppendChild(appendedElementEmail);
    xmlDoc.DocumentElement.AppendChild(subRoot);
     
    xmlDoc.Save("F:/Documents and Settings/Administrator/Desktop/Account.xml");if(!File.Exists("F:/Documents and Settings/Administrator/Desktop/Account.xml"))
    {
     
    XmlTextWriter textWritter=new XmlTextWriter("F:/Documents and Settings/Administrator/Desktop/Account.xml", null); 
    textWritter.WriteStartDocument();
    textWritter.WriteStartElement("USERS");
    textWritter.WriteEndElement();
     
    textWritter.Close();
    }
     
     
     
    XmlDocument xmlDoc=new XmlDocument();
     
    xmlDoc.Load("F:/Documents and Settings/Administrator/Desktop/Account.xml");
     
    XmlElement subRoot=xmlDoc.CreateElement("User");
    //UserName
    XmlElement appendedElementUsername=xmlDoc.CreateElement("UserName");
    XmlText xmlTextUserName=xmlDoc.CreateTextNode(txtUsrName.Text.Trim());
    appendedElementUsername.AppendChild(xmlTextUserName);
    subRoot.AppendChild(appendedElementUsername);
    xmlDoc.DocumentElement.AppendChild(subRoot);
    //Email
     
    XmlElement appendedElementEmail=xmlDoc.CreateElement("Email");
    XmlText xmlTextEmail=xmlDoc.CreateTextNode(txtEmail.Text.Trim());
    appendedElementEmail.AppendChild(xmlTextEmail);
    subRoot.AppendChild(appendedElementEmail);
    xmlDoc.DocumentElement.AppendChild(subRoot);
     
    xmlDoc.Save("F:/Documents and Settings/Administrator/Desktop/Account.xml");
