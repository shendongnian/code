    public byte[] DisplayPhoto(byte[] photo)
    {
          if (!(photo == null))
          {
              MemoryStream stream = new MemoryStream();
              // .......
              return  stream.ToArray();
          }
          else
          {
             
              // Convert your existing ResidentImage.Source to a byte array and return it
          }
    }
 
