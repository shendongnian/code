    public static class DirectoryInfoExtender
    {
        public static void CreateDirectory(this DirectoryInfo instance)
        {
            if (instance.Parent != null)
            {
                CreateDirectory(instance.Parent);
            }
            if (!instance.Exists)
            {
                instance.Create();
            }
        }
    }
