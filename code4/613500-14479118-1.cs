            using (System.Drawing.Image image = System.Drawing.Bitmap.FromStream(fs))
            {
                int iWidth = (int)Math.Round((decimal)image.Width);
                int iHeight = (int)Math.Round((decimal)image.Height);
               if(iWidth > 1024 || iHeight > 768)
               {
                    // here you can throw your message
               }
            }
