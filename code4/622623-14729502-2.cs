    public Image<Bgr, Byte> Draw(String modelImageFileName, String observedImageFileName, out long matchTime,int i)
    {
       Image<Gray, Byte> modelImage = new Image<Gray, byte>(dict[modelImageFileName);
       Image<Gray, Byte> observedImage = new Image<Gray, byte>(dict[observedImageFileName]);
    }
