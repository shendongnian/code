     public static class TextureContent
        {
            public static Dictionary<string, T> LoadListContent<T>(this ContentManager contentManager, string contentFolder)
            {
                DirectoryInfo dir = new DirectoryInfo(contentManager.RootDirectory + "/" + contentFolder);
                if (!dir.Exists)
                    throw new DirectoryNotFoundException();
                Dictionary<String, T> result = new Dictionary<String, T>();
    
                FileInfo[] files = dir.GetFiles("*.*");
                foreach (FileInfo file in files)
                {
                    string key = Path.GetFileNameWithoutExtension(file.Name);
    
    
                    result[key] = contentManager.Load<T>(contentFolder + "/" + key);
                }
                return result;
            }
        }
