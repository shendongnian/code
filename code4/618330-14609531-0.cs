    //Offest is now long
    long offset = 4252580352;
    
    byte[] byteArr = new byte[layerPixelCount];
    using (FileStream fs = File.OpenRead(recFileName))
    {
       using (BinaryReader br = new BinaryReader(fs))
        {
            fs.Seek(offset, SeekOrigin.Begin);
    
            for (long i = 0; i < byteArr.Length; i++)
            {
                byteArr[i] = (byte)(br.ReadUInt16() / 256);
            }
        }
    }
