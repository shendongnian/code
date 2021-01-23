    static class ResourceManager
    {
        public static string ServerFilesLocation { 
            get { 
                return String.Format(Resources.ServerFilesDirectory, Environment.CurrentDirectory);
                // ServerFilesDirectory = "{0}\\Server Files\\" or something similar
            } 
        }
    }
