     XmlDocument xml = new XmlDocument();
                XmlElement root = xml.CreateElement("ScriptFileNames");
                xml.AppendChild(root);
    
                XmlElement comment = xml.CreateElement("SqlEye");
                root.AppendChild(comment);
    
                var WarningClassData = (from items in lstWarningClass
                                        select items).GroupBy(t => t.SqlEyeWarning).ToList();
    
                foreach (var data in WarningClassData)
                {
                    XmlElement SqlEyeWarnings = xml.CreateElement("SqlEyeWarnings");
                    SqlEyeWarnings.SetAttribute("Name", data.Key);
                    comment.AppendChild(SqlEyeWarnings);
                    for (int i = 0; i < data.Count(); i++)
                    {
                        XmlElement File = xml.CreateElement("File");
                        File.SetAttribute("Name", data.ElementAt(i).FileName);
                        SqlEyeWarnings.AppendChild(File);
                    }
                }
    
                var RemarkClassData = (from items in lstRemarkClass
                                       select items).GroupBy(t => t.SqlEyeRamark).ToList();
    
                foreach (var data in RemarkClassData)
                {
                    XmlElement SqlEyeRemarks = xml.CreateElement("SqlEyeRemarks");
                    SqlEyeRemarks.SetAttribute("Name", data.Key);
                    comment.AppendChild(SqlEyeRemarks);
                    for (int i = 0; i < data.Count(); i++)
                    {
                        XmlElement File = xml.CreateElement("File");
                        File.SetAttribute("Name", data.ElementAt(i).FileName);
                        SqlEyeRemarks.AppendChild(File);
                    }
                }
    
                xml.Save(@"F:\\test.xml")
