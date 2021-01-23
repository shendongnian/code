    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect); 
    
    
    Rect rect = new Rect ();
    GetWindowRect(GetForegroundWindow(), out rect);
    
    //calculate width and height from rect
    
    using (Bitmap bitmap = new Bitmap(width, height))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            Size size = new System.Drawing.Size(width, height);
            g.CopyFromScreen(new Point(rect.Left, rect.Top), Point.Empty, size);
        }
        bitmap.Save("C://test.jpg", ImageFormat.Jpeg);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
