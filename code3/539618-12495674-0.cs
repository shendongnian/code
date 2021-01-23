        public static Image Texture2Image(Texture2D texture)
        {
            Image img;
            using (MemoryStream MS = new MemoryStream())
            {
                texture.SaveAsPng(MS, texture.Width, texture.Height);
                //Go To the  beginning of the stream.
                MS.Seek(0, SeekOrigin.Begin);
                //Create the image based on the stream.
                img = Bitmap.FromStream(MS);
            }
            return img;
        }
