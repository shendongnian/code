    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern void SetWindowText(int hWnd, String text);
    private void button3_Click(object sender, EventArgs e)
    {
        IntPtr wHnd = this.Handle;//assuming you are in a C# form application
        SetWindowText(wHnd.ToInt32(), "New Window Title");
    }
