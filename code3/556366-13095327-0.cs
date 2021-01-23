                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.DTD;
                settings.ProhibitDtd = false;
                settings.XmlResolver = new MyCoolResolver();
                binDirectory = binDirectory + "/content";
                string myFileLocation = binDirectory + "/MyFile.svg";
                using (XmlReader reader = XmlReader.Create(myFileLocation , settings))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            _xmlDocument.Load(reader);
                        }
                    }
                    catch (XmlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
