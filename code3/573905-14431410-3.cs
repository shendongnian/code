    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    
    [StructLayout(LayoutKind.Explicit)]
    struct LParamLocation
    {
        [FieldOffset(0)]
        int Number;
        [FieldOffset(0)]
        public short X;
        [FieldOffset(2)]
        public short Y;
        public static implicit operator int(LParamLocation p)
        {
            return p.Number;
        }
    }
    
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        var process = Process.GetProcessesByName("skype");
        LParamLocation points = new LParamLocation();
        points.X = (short)PointToScreen(e.Location).X;
        points.Y = (short)PointToScreen(e.Location).Y;
        SendMessage(process[0].MainWindowHandle, 0x201, 0, points); //MouseLeft down message
        SendMessage(process[0].MainWindowHandle, 0x202, 0, points); //MouseLeft up message
    }
