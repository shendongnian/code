    public static class Extension Methods
    {
            public static List<T> LoadContentFolder<T>(this ContentManager contentManager, string contentFolder)
            {
                DirectoryInfo dir = new DirectoryInfo(contentManager.RootDirectory + "/" + contentFolder);
                if (!dir.Exists)
                    throw new DirectoryNotFoundException();
                List<T> result = new List<T>();
    
                FileInfo[] files = dir.GetFiles("*.*");
                foreach (FileInfo file in files)
                {
                    result.Add(contentManager.Load<T>(contentFolder + "/" + file.Name.Split('.')[0]));
                }
                return result;
            }
    }
