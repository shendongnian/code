            byte[] bytearray = null;
            using (MemoryStream ms = new MemoryStream())
            {
                if (imgphotochoser.Source == null)
                {
                   
                }
                else
                {
                     WriteableBitmap wbitmp = new WriteableBitmap((BitmapImage)imgphotochoser.Source);
                    wbitmp.SaveJpeg(ms, 46, 38, 0, 100);
                    bytearray = ms.ToArray();
                }
            }
            string str = Convert.ToBase64String(bytearray);
