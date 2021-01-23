    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
        return  ms.ToArray();
    }
    
    public Image byteArrayToImage(byte[] byteArrayIn)
    {
         MemoryStream ms = new MemoryStream(byteArrayIn);
         Image returnImage = Image.FromStream(ms);
         return returnImage;
    }
...
     System.Drawing.Image theImage = null;
     try
     {
         SqlCommand cmd = getSQLCommand("SELECT img FROM pm005.images WHERE id="+imageID);
         byte[] Img = (byte[])cmd.ExecuteScalar();
         theImage = byteArrayToImage(Img);
     }
     catch
     {
    
     }
     finally
     {
    
     }    
     return theImage;    
    } 
