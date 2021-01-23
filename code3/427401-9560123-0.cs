        public override async Load()
        {
            var file = await GetPackagedFile("assets", "world.xml");
            LoadXml(file);
        }
        private async void LoadXml(StorageFile file)
        {
            XmlLoadSettings settings = new XmlLoadSettings() { ValidateOnParse = false };
            XmlDocument xmlDoc = await XmlDocument.LoadFromFileAsync(file, settings);
            foreach (IXmlNode xmlNode in xmlDoc.ChildNodes)
            {
                //ProcessNode(xmlNode);
            }
        }
        private async Task<StorageFile> GetPackagedFile(string folderName, string fileName)
        {
            StorageFolder installFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            if (folderName != null)
            {
                StorageFolder subFolder = await installFolder.GetFolderAsync(folderName);
                return await subFolder.GetFileAsync(fileName);
            }
            else
            {
                return await installFolder.GetFileAsync(fileName);
            }
        }
    }
