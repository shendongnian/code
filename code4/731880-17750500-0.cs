            public void ResizeImage(string fileName, int width, int height)
            {
                using (Image image = Image.FromFile(fileName))
                {
                    new Bitmap(image, width, height).Save(fileName);
                }
            }
