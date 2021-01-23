    Byte[] startBytes;
            Byte[] endBytes;
            using (System.IO.MemoryStream inStream = new System.IO.MemoryStream(startBytes))
            {
                System.IO.MemoryStream outStream = new MemoryStream();
                System.Drawing.Bitmap.FromStream(inStream).Save(outStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                endBytes = outStream.GetBuffer();
            }
