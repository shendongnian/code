    public Bitmap stringToImage(string inputString)
    {
       byte[] imageBytes = Encoding.Unicode.GetBytes(inputString);
       using (MemoryStream ms = new MemoryStream(imageBytes))
       {
           return new Bitmap(ms);
       }
    }
