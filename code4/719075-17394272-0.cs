                string elementName = "";
                
                List<string[]> Champion = new List<string[]>();
                string name = "";            
    
                while (reader.Read())  // go throw the xml file
                {
    
                    if (reader.NodeType == XmlNodeType.Element) //get element from xml file 
                    {
    
                        elementName = reader.Name;
                    }
                    else
                    {
    
                        if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue)) //fet the value of element
                        {
                            switch (elementName) // switch on element name weather Name or Counter
                            {
                                case "Name":
                                    name = reader.Value;
                                    break;
                                case "Counter":
                                    string[] value = new string[] { name, reader.Value }; //store result to list of array of string
                                    Champion.Add(value);
                                    break;
    
                            }
                        }
                    }
                }
