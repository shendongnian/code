        public static byte[] BufferFromImage(BitmapImage img)
        {
            byte[] result = null;
            if (img != null)
            {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(img));
                encoder.Save(memStream);
                result = memStream.GetBuffer();
            }
            return result;
        }
