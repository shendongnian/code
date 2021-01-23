        private static void AddFilesToUnitTestProject(FileInfo[] files, string measureBaseDirPath, string measureDataDirSuffix)
        {
            var unitTestProjectPath = measureBaseDirPath + _unitTestProjectFile;
            var unitTestProjectFile = XDocument.Load(unitTestProjectPath);
            var itemGroup = unitTestProjectFile.Nodes()
                              .OfType<XElement>()
                              .DescendantNodes()
                              .OfType<XElement>().First(xy => xy.Name.LocalName == "ItemGroup");
            
            foreach (var fileInfo in files)
            {
                var xelem = AddProjectContent(measureDataDirSuffix + fileInfo.Name, unitTestProjectFile);
                itemGroup.Add(xelem);
            }
            unitTestProjectFile.Save(unitTestProjectPath);
        }
        private static void AddFileToUnitTestProject(string pathToAdd, string measureBaseDirPath, string measureDataDir)
        {
            var unitTestProjectPath = measureBaseDirPath + _unitTestProjectFile;
            var unitTestProjectFile = XDocument.Load(unitTestProjectPath);
            var itemGroup =
            unitTestProjectFile.Nodes()
                               .OfType<XElement>()
                               .DescendantNodes()
                               .OfType<XElement>().First(xy => xy.Name.LocalName == "ItemGroup");
            var xelem = AddProjectContent(pathToAdd, unitTestProjectFile);
            itemGroup.Add(xelem);
            unitTestProjectFile.Save(unitTestProjectPath);
        }
    private static XElement AddProjectContent(string pathToAdd, XDocument doc) 
    { 
    	XNamespace rootNamespace = doc.Root.Name.NamespaceName; 
    	var xelem = new XElement(rootNamespace + "Content"); 
    	xelem.Add(new XAttribute("Include", pathToAdd)); 
    	xelem.Add(new XElement(rootNamespace + "CopyToOutputDirectory", "Always")); 
    	return xelem; 
    }
