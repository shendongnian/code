        String path = @"C:\iBoxProductValidator.xml";
        String pathResult = @"C:\iBoxProductValidatorResult.xml";
		XmlDocument configDoc = new XmlDocument();
		configDoc.Load(path);
		XmlNodeList projectNodes = configDoc.GetElementsByTagName("File");
		for (int i = 0; i < projectNodes.Count; i++)
		{
			if (projectNodes[i].Attributes["version"] != null)
			{
				projectNodes[i].Attributes.Remove(projectNodes[i].Attributes["version"]);
			}
		}
        configDoc.Save(pathResult);
