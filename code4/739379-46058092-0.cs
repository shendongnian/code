    private static void SaveImageToRawFile(string strDeviceName, Byte[] Image, int nImageSize)
        {
            string strFileName = strDeviceName;
            strFileName += ".raw";
            FileStream vFileStream = new FileStream(strFileName, FileMode.Create);
            BinaryWriter vBinaryWriter = new BinaryWriter(vFileStream);
            for (int vIndex = 0; vIndex < nImageSize; vIndex++)
            {
                vBinaryWriter.Write((byte)Image[vIndex]);
            }
            vBinaryWriter.Close();
            vFileStream.Close();
        }
        private static void LoadRawFile(string strDeviceName, out Byte[] Buffer)
        {
            FileStream vFileStream = new FileStream(strDeviceName, FileMode.Open);
            BinaryReader vBinaryReader = new BinaryReader(vFileStream);
            Buffer = new Byte[vFileStream.Length];
            Buffer = vBinaryReader.ReadBytes(Convert.ToInt32(vFileStream.Length));
       
            vBinaryReader.Close();
            vFileStream.Close();
        }
