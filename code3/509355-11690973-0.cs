        private string GetHexStringFromImage(object sender, RoutedEventArgs e)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(@"E:\SourceDirectory\SourceFile.png");
            byte[] byteArray = imageToByteArray(image);
            StringBuilder hexBuilder = new StringBuilder();
            foreach (byte b in byteArray)
            {
                string hexByte = b.ToString("X");
                string temp = hexByte.Length % 2 == 0 ? hexByte : hexByte.PadLeft(2, '0');
                hexBuilder.Append(temp);
            }
            return hexBuilder.ToString();
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        private void SaveImageFromHexString(string stringFromDB)
        {
            int length = stringFromDB.Length;
            List<byte> byteList = new List<byte>();
            for (int i = 0; i < length; i += 2)
            {
                byte x = Convert.ToByte(stringFromDB.Substring(i, 2), 16);
                byteList.Add(x);
            }
            byte[] newbyteArray = byteList.ToArray();
            System.Drawing.Image newImage = byteArrayToImage(newbyteArray);
            newImage.Save(@"E:\DestinationDirectory\DestinationFile.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
