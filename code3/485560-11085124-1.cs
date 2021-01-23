            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.QualityLevel = 100;          
           // byte[] bit = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {               
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(stream);
                byte[] bit = stream.ToArray(); 
                stream.Close();               
            }
