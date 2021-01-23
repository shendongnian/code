    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern int GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);
    private void button1_Click(object sender, EventArgs e)
    {
        int nret;
        var className = new StringBuilder(255);
        nret = GetClassName(button1.Handle, className, className.Capacity);
        if (nret != 0)
            MessageBox.Show("Classname is " + className.ToString());
        else
            MessageBox.Show("Error getting window class name");
    }
