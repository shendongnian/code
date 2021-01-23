    private static XElement CreateXML(DirectoryInfo dir)
        {
            var xmlInfo = new XElement("serverfiles");
            //get all the files first
            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }
            //get subdirectories
            foreach (var subDir in dir.GetDirectories())
            {
                xmlInfo.Add(CreateSubdirectoryXML(subDir));
            }
            return xmlInfo;
        }
        private static XElement CreateSubdirectoryXML(DirectoryInfo dir)
        {
            //get directories
            var xmlInfo = new XElement("folder", new XAttribute("name", dir.Name));
            //get all the files first
            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }
            //get subdirectories
            foreach (var subDir in dir.GetDirectories())
            {
                xmlInfo.Add(CreateSubdirectoryXML(subDir));
            }
            return xmlInfo;
        }
