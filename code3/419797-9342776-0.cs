        public static int[][] ImageToArray(Bitmap bmp) {
            int height = bmp.Height;   // Slow properties, read them once
            int width = bmp.Width;
            var arr = new int[height][];
            var data = bmp.LockBits(new Rectangle(0, 0, width, height), 
                       System.Drawing.Imaging.ImageLockMode.ReadOnly, 
                       System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try {
                for (int y = 0; y < height; ++y) {
                    arr[y] = new int[width];
                    System.Runtime.InteropServices.Marshal.Copy(
                        (IntPtr)((long)data.Scan0 + (height-1-y) * data.Stride),
                        arr[y], 0, width);
                }
            }
            finally {
                bmp.UnlockBits(data);
            }
            return arr;
        }
