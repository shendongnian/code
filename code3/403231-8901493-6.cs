      public void DecodePhoto(byte[] byteVal)
            {
                if (byteVal == null) return ;
              
    
                try
                {
                    MemoryStream strmImg = new MemoryStream(byteVal);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                    MugShot.Source = myBitmapImage;
                }
                catch (Exception ex)
                {
                    string message = ex.Message; 
                }
    
            }
