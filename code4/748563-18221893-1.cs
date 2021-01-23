                System.Drawing.Image bm = theBitmapYouGeneratedEarlier;
                if (bm == null)
                {
                    Response.Write("Failed to load image");
                    return;
                }
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = "image/jpeg";
                bm.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Response.OutputStream.Flush();
                bm.Dispose();
