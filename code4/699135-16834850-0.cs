    using (XmlWriter writer = XmlWriter.Create(FilePath + FileName))
				{
					writer.WriteStartDocument();
					writer.LookupPrefix("xs");
					writer.WriteStartElement("TestForXML");
						
						
							foreach (DataRow currentRow in dt.Rows)
							{
							writer.WriteStartElement("Test");
								writer.WriteElementString("", Convert.ToString(currentRow[""]));
								writer.WriteElementString("", Convert.ToString(currentRow[""]));
								//writer.WriteElementString("", "");
								writer.WriteElementString("", "");
							writer.WriteEndElement();
					
							}
							
						writer.WriteEndElement();	
					writer.WriteEndDocument();
						
				}
				
				System.IO.FileInfo f = new System.IO.FileInfo(FilePath + FileName);
				string destinationFileName = System.IO.Path.GetFileNameWithoutExtension(FilePath + f.Name) + System.DateTime.Now.ToString("ddMMyy_HHmmss") + ".xml";
				f.CopyTo (FilePath + destinationFileName);
				
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.Schemas.Add(null, FilePath + XSDFile); 
				settings.ValidationType = ValidationType.Schema; 
				XmlDocument document = new XmlDocument();
				document.Load(FilePath + FileName);
				XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);
				while(rdr.Read()){}
