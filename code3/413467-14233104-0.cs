                 Bitmap newBitmap;
                 using (MemoryStream memoryStream = new MemoryStream(byteArrayIn))
                 {
                    using (Image newImage = Image.FromStream(memoryStream))
                    {
                       newBitmap = new Bitmap(newImage);
                    }
                 }
                 return newBitmap;
