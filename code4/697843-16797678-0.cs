    [DllImport("user32.dll")]
    private static extern int GetSystemMetrics(int index);
    private static int WindowBorderWidth
    {
        get { return GetSystemMetrics(32); }
    }
    private static int WindowBorderHeight
    {
        get { return GetSystemMetrics(33); }
    }
    protected override void OnLoad(EventArgs e)
    {
        int increaseWidth = WindowBorderWidth * 2;
        int increaseHeight = WindowBorderHeight * 2;
        this.Size = new Size(
            this.Size.Width + increaseWidth,
            this.Size.Height + increaseHeight
        );
    }
