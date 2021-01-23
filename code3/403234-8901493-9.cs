      public void DecodePhoto(byte[] byteVal)
            {
                if (byteVal == null)
    { 
    return ;
    }
              
    
                try
                {
                    MemoryStream strmImg = new MemoryStream(byteVal);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                    MyImage.Source = myBitmapImage;
                }
                catch (Exception)
                {
                }
            }
