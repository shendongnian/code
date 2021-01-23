     byte[] fileBytes = Convert.FromBase64String(s);
        
                    using (MemoryStream ms = new MemoryStream(fileBytes, 0, fileBytes.Length))
                    {
                        ms.Write(fileBytes, 0, fileBytes.Length);
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(ms);
                        return bitmapImage;
                    }
