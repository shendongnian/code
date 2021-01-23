    // *** API Declarations ***
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
    private const int WM_SETREDRAW = 11;
    
    // *** DataGridView population ***
    SendMessage(dataGridView1.Handle, WM_SETREDRAW, false, 0);
    // Add rows to DGV here
    SendMessage(dataGridView1.Handle, WM_SETREDRAW, true, 0);
    dataGridView1.Refresh();
