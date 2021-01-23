    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern bool EnableWindow(IntPtr hWnd, bool enable);
    public static DialogResult ShowDialogSpecial(this Form formToBeShown, Form parent)
    {
        parent.BeginInvoke(new Action(() => EnableWindow(parent.Handle, true)));
        formToBeShown.ShowDialog(parent);
        return formToBeShown.DialogResult;
    }
