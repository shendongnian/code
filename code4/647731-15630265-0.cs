      private static void SaveXml(string pathAndFileName, DataTable source)  
      {  
         XmlDocument xmlDoc = new XmlDocument();  
         var root = xmlDoc.CreateElement("root");  
         xmlDoc.AppendChild(root);  
         foreach (DataRow row in source.Rows)  
         {
            var dataElement = xmlDoc.CreateElement("data");
            var openAttribute = xmlDoc.CreateAttribute("open");
            openAttribute.Value = "1";
            dataElement.Attributes.Append(openAttribute);
            dataElement.InnerText = row["value"].ToString();
            root.AppendChild(dataElement);
         }
         xmlDoc.Save(pathAndFileName);
      }
