        // Read from a file line by line
        public async Task ReadFile()
        {
            try
            {
                // get the file
                StorageFile myStorageFile = await localFolder.GetFileAsync("MyDocument.txt");
                var readThis = await FileIO.ReadLinesAsync(myStorageFile);
                foreach (var line in readThis)
                {
                    String myStringLine = line;
                }
                Debug.WriteLine("File read successfully.");
            }
            catch(FileNotFoundException)
            {              
            }
        }
        // Write to a file line by line
        public async void SaveFile()
        {
            try
            {
                // set storage file
                StorageFile myStorageFile = await localFolder.CreateFileAsync("MyDocument.txt", CreationCollisionOption.ReplaceExisting);
                List<String> myDataLineList = new List<string>();
                await FileIO.WriteLinesAsync(myStorageFile, myDataLineList);
                Debug.WriteLine("File saved successfully.");
            }
            catch(FileNotFoundException)
            {              
            }
        }
