    private void WriteToFile(IsolatedStorageFile storeFile, string content)
            {
                using (IsolatedStorageFileStream fileStream = storeFile.OpenFile("Userdata\\Userdata.txt", FileMode.Open, FileAccess.Write){ // Exception: not allowed on IsolatedStorageFile
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(content);
                }
            }
    }
    
            private string ReadFile(IsolatedStorageFile storeFile)
            {
                using(IsolatedStorageFileStream fileStream = storeFile.OpenFile("Userdata\\Userdata.txt", FileMode.Open, FileAccess.Read){
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    return reader.ReadLine().Trim();
                }
            }
    }
