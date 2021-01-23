    public Image byteArrayToImage(byte[] bytesArr)
    {
        using (MemoryStream memstr = new MemoryStream(bytesArr))
        {
            Image img = Image.FromStream(memstr);
            return img;
        }
    }
