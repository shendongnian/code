    if (!myIsolatedStorage.FileExists("History.xml"))
                    {
                        using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("History.xml", FileMode.Create, myIsolatedStorage))
                        {
                            XmlWriterSettings settings = new XmlWriterSettings();
                            settings.Indent = true;
                            using (XmlWriter writer = XmlWriter.Create(isoStream, settings))
                            {
                                writer.WriteStartElement("History", "");
                                writer.WriteStartElement("SmSHistory", "");
    
                                writer.WriteStartElement("RecipentName", "");
                                writer.WriteString(RecipentName);
                                writer.WriteEndElement();
    
                                writer.WriteStartElement("RecipentNumber", "");
                                writer.WriteString(RecipentNumber);
                                writer.WriteEndElement();
    
                                writer.WriteStartElement("TimeStamp", "");
                                writer.WriteString(TimeStamp);
                                writer.WriteEndElement();
    
                                writer.WriteStartElement("Message", "");
                                writer.WriteString(Message);
                                writer.WriteEndElement();
    
                                // Ends the document
                                writer.WriteEndDocument();
    
                                // Write the XML to the file.
                                writer.Flush();
                            }
                        }
                    }
    
                    else
                    {
                        XDocument loadedData;
                        using (Stream stream = myIsolatedStorage.OpenFile("History.xml", FileMode.Open, FileAccess.ReadWrite))
                        {
                            // Load History.xml From Isolated Storage
                            loadedData = XDocument.Load(stream);
    
                            // Add SMS History Tags to XMLDocument
                            var RootNode = new XElement("SmSHistory");
                            var RecipentN = new XElement("RecipentName", RecipentName);
                            var RecipentNo = new XElement("RecipentNumber", RecipentNumber);
                            var Time = new XElement("TimeStamp", TimeStamp);
                            var MessageBody = new XElement("Message", Message);
                            RootNode.Add(RecipentN, RecipentNo, Time, MessageBody);
    
                            // Find Root Element And Descedents and Append New Node After That
                            var root = loadedData.Element("History");
                            var rows = root.Descendants("SmSHistory");
                            var lastRow = rows.Last();
                            lastRow.AddAfterSelf(RootNode);
                        }
    
                        // Save To History.xml File 
                        using (IsolatedStorageFileStream myStream = new IsolatedStorageFileStream("History.xml", FileMode.Create, myIsolatedStorage))
                        {
                            loadedData.Save(myStream);
                        }
                    }
                }
