    public void ShowWindow()
    {
        Show();
        WindowState = System.Windows.WindowState.Normal;
    }
    void notifyIcon1_Click(object sender, EventArgs e)
    {
        ShowWindow();
    }
