        private string GetHexStringFromImage()
        {
            //Read your image file
            System.Drawing.Image image = System.Drawing.Image.FromFile(@"E:\SourceDirectory\SourceFile.png");
            //Convert image it to byte-array
            byte[] byteArray = ImageToByteArray(image);
            //Convert byte-array to Hex-string
            StringBuilder hexBuilder = new StringBuilder();
            foreach (byte b in byteArray)
            {
                string hexByte = b.ToString("X");
                //make sure each byte is represented by 2 Hex digits
                string temp = hexByte.Length % 2 == 0 ? hexByte : hexByte.PadLeft(2, '0');
                hexBuilder.Append(temp);
            }
            //return Hex-string to save to DB
            return hexBuilder.ToString();
        }
        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private void SaveImageFromHexString(string stringFromDB)
        {
            //Convert Hex-string from DB to byte-array
            int length = stringFromDB.Length;
            List<byte> byteList = new List<byte>();
            //Take 2 Hex digits at a time
            for (int i = 0; i < length; i += 2)
            {
                byte byteFromHex = Convert.ToByte(stringFromDB.Substring(i, 2), 16);
                byteList.Add(byteFromHex);
            }
            byte[] newbyteArray = byteList.ToArray();
            //Convert byte-array to image file
            System.Drawing.Image newImage = ByteArrayToImage(newbyteArray);
            //Save image file
            newImage.Save(@"E:\DestinationDirectory\DestinationFile.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        private System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
            }
        }
