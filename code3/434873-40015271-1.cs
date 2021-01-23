            BitmapData bitmapdata = copy.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] bytes = new byte[source.Width * source.Height * 4];
            //copy the bytes from the Scan0 pointer to our byte array
            Marshal.Copy(bitmapdata.Scan0, bytes, 0, bytes.Length);
            
            //swap the red and blue bytes
            for(int a = 0; a < bytes.Length; a += 4) {
                byte tmp = bytes[a];
                bytes[a] = bytes[a + 2];
                bytes[a + 2] = tmp;
            }
            copy.UnlockBits(bitmapdata);
            return bytes;
