    class SetWindowSize
    {
        public const string savePath = "file.dat";
    
        public int width {get; set; }
        public int height {get; set; }
    
        public static void SaveData(string width, string height)
        {            
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(savePath, FileMode.Create)))
            {
                binaryWriter.Write(width);
                binaryWriter.Write(height);
                SetWindowSize.width = width;
                SetWindowSize.height = height;
            }
        }
    }
    }
