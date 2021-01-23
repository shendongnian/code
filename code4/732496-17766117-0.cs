            public static List<ProjectObj> getProjectsList()
            {
                List<ProjectObj> ret = new List<ProjectObj>();
                IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
    
                if (!file.DirectoryExists("/projects/")) //trying to validate the dir exists
                    return ret;
    
                string[] fileNames = file.GetFileNames("/projects/");
    
                foreach (string filename in fileNames)
                {
                    if (!file.FileExists("/projects/" + filename)) //validate just one more time...
                        continue;
    
                    ProjectObj tempProj = new ProjectObj();
    
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("/projects/" + filename, FileMode.Open, file))
                    {
                        using (StreamReader reader = new StreamReader(isoStream))
                        {
                        }
                    }
