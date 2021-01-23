        private string GetHexStringFromImage(System.Drawing.Image imageToConvert)
        {
            //Convert image it to byte-array
            byte[] byteArray;
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byteArray = ms.ToArray();
            }
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
        private System.Drawing.Image GetImageFromHexString(string hexSting)
        {
            //Convert Hex-string from DB to byte-array
            int length = hexSting.Length;
            List<byte> byteList = new List<byte>();
            //Take 2 Hex digits at a time
            for (int i = 0; i < length; i += 2)
            {
                byte byteFromHex = Convert.ToByte(hexSting.Substring(i, 2), 16);
                byteList.Add(byteFromHex);
            }
            byte[] byteArray = byteList.ToArray();
            //Convert byte-array to image file and return the image
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(stream);
            }
        }
