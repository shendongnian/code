            string path = @"XML file";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                string country = "";
                string Year = "";
                string count = "";
                string tss = "";
                string tss2 = "";
                while (reader.ReadToFollowing("Row"))
                {
                    XmlReader reader2 = reader.ReadSubtree();
                    while (reader2.Read())
                    {
                        if (reader2.NodeType == XmlNodeType.Element)
                        {
                            if (reader2.Name == "RowType")
                            {
                                country = reader2.GetAttribute("Label");
                                country = country.Replace("'", ""); //country_year = reader.ReadElementContentAsString(); -> "Scotland" -> 1985
                            }
                            else if (reader2.Name == "Year")
                            {
                                //IF XML IS -> <Year Id="11">1994<Year/>
                                //Then -> Year = reader2.GetAttribute("Label")
                                Year = reader2.GetAttribute("Label"); //-> 1994
                            }
                            else if (reader2.Name == "Value")
                            {
                                count = reader2.ReadElementContentAsString(); 
                            }
                            else if (reader2.Name == "Field")
                            {
                                if (reader2.GetAttribute("Label") == "Country")
                                {
                                    tss = reader2.ReadElementContentAsString(); //I understand that this is what you want to read, instead the Label name
                                }
                                else if (reader2.GetAttribute("Label") == "Soccer")
                                {
                                    tss2 = reader2.ReadElementContentAsString();//I understand that this is what you want to read, instead the Label name
                                }
                            }
                        }
                    }
                }
            }
