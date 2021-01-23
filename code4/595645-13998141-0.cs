        // READ FILE
        public async void ReadFile()
        {
            // settings
            var path = @"MyFolder\MyFile.txt";
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            
            // acquire file
            var file = await folder.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            foreach (var line in readFile)
            {
                Debug.WriteLine("" + line.Split(';')[0]);
            }
         }
