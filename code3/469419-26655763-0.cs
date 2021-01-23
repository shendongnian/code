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
        // WinApi here
        Win32.ReleaseCapture();
        Win32.SendMessage((sender as Control).Handle, Win32.WM_NCLBUTTONDOWN, (IntPtr) HT.CAPION, IntPtr.Zero);
    }
