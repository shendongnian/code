     foreach (XmlNode option in options) 
                     { 
                         foreach (XmlNode setting in option) 
                         { 
                             if (setting.NodeType == XmlNodeType.Comment)
                             {
                                 continue;
                             }
                             string key = setting.Attributes["key"].Value; 
                             string value = setting.Attributes["value"].Value;
