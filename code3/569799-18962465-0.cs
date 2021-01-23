        static void Main(string[] args)
        {
            IBarcodeWriter writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.AZTEC
                };
            Bitmap aztecBitmap;
            var result = writer.Write("I love you ;)");
            aztecBitmap = new Bitmap(result);
            using (var stream = new FileStream("test.bmp", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var aztecAsBytes = ImageToByte(aztecBitmap);
                stream.Write(aztecAsBytes, 0, aztecAsBytes.Length);
            }
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
