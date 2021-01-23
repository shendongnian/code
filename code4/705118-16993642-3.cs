    static class MessageBoxEx
    {
        public static void Show(string content, MessageBoxOptions options)
        {
            MessageBox.Show(content, "", MessageBoxButtons.OK, MessageBoxIcons.None,          MessageBoxDefaultButton.Button1, options);
        }
    }
