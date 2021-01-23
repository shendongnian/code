    xmlDoc.Load(filePath);
                XmlNode node = xmlDoc.SelectSingleNode("/PolicyChangeSet");
                node.Attributes["username"].Value = AppVars.Username;
                node.Attributes["description"].Value = "Adding new .tiff image.";
    
                node = xmlDoc.SelectSingleNode("/PolicyChangeSet/Attachment");
                node.Attributes["name"].Value = "POLICY";
                node.Attributes["contentType"].Value = "content Typeeee";
    xmlDoc.Save(filePath);
