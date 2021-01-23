     using (XmlTextReader xmlTextReader = new XmlTextReader("FILE_NAME.xml"))
     {
        while (xmlTextReader.Read())
        {
            switch (xmlTextReader.NodeType)
            {
                // ... Process node types here ex. XmlNodeType.Element
            }
         }
     }
