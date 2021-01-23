    public static class SetWindowSize
    {
        public static void SaveData(string width, string height)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open("file.dat", FileMode.Create)))
            {
                // 3. Use foreach and write all 12 integers.
                binaryWriter.Write(height, width);
            }
        }
    }    
