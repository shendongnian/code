    const uint WM_NCLBUTTONDOWN = 161;
    const uint HTCAPTION = 2;
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr window, uint message, IntPtr wParam, IntPtr lParam);
    public Form1()
    {
        PictureBox picBox = new PictureBox();
        picBox.Text = "this control is crazy!";
        picBox.BackColor = Color.Red;
        picBox.SetBounds(8, 8, 128, 64);
        picBox.MouseDown += OnMouseDown;
        Controls.Add(picBox);
    }
    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage((sender as Control).Handle, WM_NCLBUTTONDOWN, (IntPtr) HTCAPION, IntPtr.Zero);
    }
