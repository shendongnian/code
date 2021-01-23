    public static void DoIt(IntPtr srcWindow)
    {
    Graphics g = Graphics.FromHwnd(srcWindow);
    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(400, 400));
    }
  
