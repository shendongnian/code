            //get directories
            var xmlInfo = new XElement("folder",                 
                new XElement("name", dir.Name),
                new XElement("lastModify", dir.LastWriteTime),
                new XElement("Attributes", dir.Attributes));
            //get subdirectories
            foreach (var subDir in dir.GetDirectories())
            {
                xmlInfo.Add(CREATEXML(subDir));
            }
            //get all the files
            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("File",
                    new XElement("name", file.Name),
                    new XElement("size", file.Length),
                    new XElement("lastModify", file.LastWriteTime),
                    new XElement("Attributes", file.Attributes.ToString())));
            }
            return xmlInfo;
