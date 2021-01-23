        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public static void HideCaret(this TextBox textBox)
        {
            HideCaret(textBox.Handle);
        }
