        public static string GetText(IntPtr control)
        {
            StringBuilder builder = new StringBuilder(40);
            IntPtr result = IntPtr.Zero;
            uint response = SendMessageTimeoutText(control, 0xd, 40, builder, APITypes.SendMessageTimeoutFlags.SMTO_NORMAL, 2000, out result);
            return builder.ToString();
        }
        [DllImport("user32.dll", EntryPoint = "SendMessageTimeout", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint SendMessageTimeoutText(
            IntPtr hWnd,
            int Msg,              // Use WM_GETTEXT
            int countOfChars,
            StringBuilder text,
            APITypes.SendMessageTimeoutFlags flags,
            uint uTImeoutj,
            out IntPtr result);
        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0,
            SMTO_BLOCK = 0x1,
            SMTO_ABORTIFHUNG = 0x2,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x8
        }
