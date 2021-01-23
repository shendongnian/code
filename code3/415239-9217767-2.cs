    public static void CopyToClipboard(string value)
    {
       Clipboard.Clear();
       Clipboard.SetText(value, TextDataFormat.Text);
    }
