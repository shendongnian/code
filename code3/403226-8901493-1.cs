      public void DecodePhoto(byte[] value)
            {
                if (value == null) return ;
                byte[] byteme = value as byte[];
                if (byteme == null) return;
    
                try
                {
                    MemoryStream strmImg = new MemoryStream(byteme);
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
