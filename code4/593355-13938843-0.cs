    private void listView1_BeforeLabelEdit(object sender, LabelEditEventArgs e)
    {
        IntPtr editWnd = IntPtr.Zero;
        editWnd = SendMessage(listView1.Handle, LVM_GETEDITCONTROL, 0, IntPtr.Zero);
        int textLen = Path.GetFileNameWithoutExtension(listView1.Items[e.Item].Text).Length;
        SendMessage(editWnd, EM_SETSEL, 0, (IntPtr) textLen);
    }
    public const int EM_SETSEL = 0xB1;
    public const int LVM_FIRST = 0x1000;
    public const int LVM_GETEDITCONTROL = (LVM_FIRST + 24);
    [DllImport("user32.dll", CharSet = CharSet.Ansi)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int len, IntPtr order);
