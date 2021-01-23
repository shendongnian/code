      private byte[] ImageToByteArray(string ImageFile)
        {
            FileStream stream = new FileStream(
                  ImageFile, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
    
            // Convert image to byte array.
            byte[] photo = reader.ReadBytes((int)stream.Length);
    
            return photo;
        }
