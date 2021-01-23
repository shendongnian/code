    while (MyVideo.VideoPreviewIsRendering || MyVideo.LiveSessionParticipantVideoIsRendering)
    {
        
            try
            {
                System.Drawing.Bitmap bitmap;
                bitmap = (videoRenderer as VideoRenderer).BitmapCopy;
                using (MemoryStream memory = new MemoryStream())
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    ImageSource imageSource;
                    Image image;
                    image = new Image();
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    imageSource = bitmapImage;
                    
                    mainWindowDispatcher.Invoke(new Action(() =>
                    {
                        image.Source = imageSource;
                        VideoContentControl.Content = image;
                    
                        memory.Close();
                    }
                }
            }
            catch (Exception)
            {
            }
        }));
    }
