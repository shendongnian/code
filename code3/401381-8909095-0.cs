        private System.Drawing.Image ObjToImg(object obj)
        {
            if (obj == null)
                return null;
            else
            {
                byte[] byteArray = (byte[])obj;
                System.Drawing.Image returnImage;
                using (var ms = new MemoryStream(byteArray, 0, byteArray.Length))
                {
                    returnImage = System.Drawing.Image.FromStream(ms);
                }
                return returnImage;
            }
        }
