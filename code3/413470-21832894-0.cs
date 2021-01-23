    public Image byteArrayToImage(byte[] byteArrayIn)
    {
        try
        {
            MemoryStream ms = new MemoryStream(byteArrayIn,0,byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            Image returnImage = Image.FromStream(ms,true);
        }
        catch { }
        return returnImage;
    }
