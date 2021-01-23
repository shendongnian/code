        try
        {
            string solutionDirPath = @"path\to\solution";
            string[] resxFilePaths = Directory.GetFiles(solutionDirPath, "*.resx", SearchOption.AllDirectories);
            foreach (string resxFilePath in resxFilePaths)
            {
                XDocument xdoc = XDocument.Load(resxFilePath);
                var iconElement = xdoc.Root.Elements("data").SingleOrDefault(el => (string)el.Attribute("name") == "$this.Icon");
                if (iconElement != null)
                {
                    iconElement.Remove();
                    xdoc.Save(resxFilePath);
                }
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
