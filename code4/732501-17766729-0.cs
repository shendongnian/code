            List<ProjectObj> ret = new List<ProjectObj>();
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            if (!file.DirectoryExists("/projects/"))
                return ret;
            foreach (String filename in file.GetFileNames("/projects/"))
            {
                IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile("/projects/"+filename, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    String fileInfo = reader.ReadToEnd();
                }
            }
