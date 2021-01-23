    byte[] imageBytes = ;// ToDOget your byte
                Bitmap newBmp = ConvertToBitmap(imageBytes);
                if (newBmp != null)
                {
                    newBmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    newBmp.Dispose();
                }
