       class Program
        {
    
            public static byte[] BytesFromImage(Image img)
            {
                Byte[] imgFile;
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);
                imgFile = ms.ToArray();
                return imgFile;
            }
    
            private static void Main(string[] args)
            {
                using (Image image = new Bitmap(100, 100))
                {
                    byte[] imgArr = BytesFromImage(image);
    
                    Console.WriteLine("Image size is: {0}", imgArr.Length);
                }
            }
