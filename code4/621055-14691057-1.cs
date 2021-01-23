    public Image getProduct_Image(byte[] imagebytes)
    {
        try
        {
            if(imagebytes == null || imagebytes.Length == 0)
                throw new InvalidDataException("The blob does not contain any data");  
       
            MemoryStream ms = new MemoryStream(imagebytes);
            ms.Position = 0;
            ms.Read((imagebytes, 0, imagebytes.Length);
            ms.ToArray();
            ms.Seek(0, SeekOrigin.Begin);
        
            System.Drawing.Image returnImage = Image.FromStream((Stream) ms);
            return new Bitmap(returnImage);
        }
        catch(Exception ex)
        {
            // deal with the exception
        }
    }
