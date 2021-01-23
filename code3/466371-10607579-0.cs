        private Image img = null;
        public long GetScreenShotSize()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bmp = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    img = Image.FromStream(ms);
                    return ms.Length;
                }
            }
        }
        public void GetScreenShot(IPEndPoint ep)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Connect(ep);
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    socket.Send(ms.ToArray(), SocketFlags.None);
                }
                img.Dispose();
                img = null;
            }
        }
