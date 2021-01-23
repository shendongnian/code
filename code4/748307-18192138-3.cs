            xmlProject project = new xmlProject();
            
            XmlDocument xd = new XmlDocument();
            XmlAttribute cheated = xd.CreateAttribute("Cheated");
            cheated.Value = "Yes";
            XmlAttribute[] xa = new XmlAttribute[]{ cheated };
            
            project.Mark = new xmlProjectMark() { IsLate = "Yes", MadeEarlyDeadline = "False", AnyAttr = xa, Value=70 };
            project.Name = "Jonathan";
            XmlSerializer writer = new XmlSerializer(typeof(xmlProject));
            StreamWriter file = new StreamWriter(@"C:\test.xml");
            writer.Serialize(file, project);
            file.Close();
