    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    private void button1_Click(object sender, EventArgs e)
    { 
        Process process = new Process();
        process.StartInfo.FileName = @...\abc.log";
        process.Start();
        process.WaitForInputIdle(); //this is the key!!
        SetForegroundWindow(this.Handle);
    }
