            // This is our output XML file
            // Technically, it should have been the same name as the input one
            // but for the purposes of testing it isn't
            StreamWriter srFile = new StreamWriter((@"testingOutputXML.xml"));
            StringWriter stWriter;
            StringBuilder sbXML = new StringBuilder();
            // Headers to play nice
            sbXML.AppendLine("<?xml version='1.0'?>");
            sbXML.AppendLine("<records>");
            DataTable dt;
            for (int i = 0; i < MetaXML.Tables.Count; i++)
            {
                // This is where we have to recreate the structure manually
                sbXML.AppendLine("<record>");
                sbXML.Append("<recordTypeId>");
                sbXML.Append((1+ i).ToString().PadLeft(2,'0'));
                sbXML.AppendLine("</recordTypeId>");
                dt = new DataTable();
                dt = MetaXML.Tables[i].Copy();
                dt.TableName = "field";
                stWriter = new StringWriter();
                dt.WriteXml(stWriter, false);              
                stWriter.WriteLine();
                
                sbXML.Append(stWriter.GetStringBuilder());
                // Need to clean up because DataTable's WriteXML() method
                // wraps the data in <DocumentElement> and </DocumentElement> tags
                sbXML.Replace("DocumentElement", "fields");
                sbXML.AppendLine("</record>");
            }
            sbXML.AppendLine("</records>");
            srFile.Write(sbXML.ToString());
            srFile.Flush();
            srFile.Close();
            MessageBox.Show("Done!");
