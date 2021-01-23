    public static class SetWindowSize
    {
        public static void SaveData(string width, string height)
        {
            File.WriteAllText("file.dat", string.Format("height: {0}, width: {1}.", height, width));
        }
    }    
