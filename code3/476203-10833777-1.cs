            using (System.Drawing.Image original = System.Drawing.Image.FromFile(fullPath))
            {
                int newHeight = original.Height / 4;
                int newWidth = original.Width / 4;
                using (System.Drawing.Bitmap newPic = new System.Drawing.Bitmap(newWidth, newHeight))
                {
                    using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(newPic))
                    {
                        gr.DrawImage(original, 0, 0, (newWidth), (newHeight));
                        string newFilename = ""; /* Put new file path here */
                        newPic.Save(newFilename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
