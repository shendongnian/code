    public class KeyMessageFilter : IMessageFilter
    {
        public enum KeyMessages
        {
            WM_KEYFIRST = 0x100,
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_CHAR = 0x102,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
            WM_SYSCHAR = 0x0106,
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == (int)KeyMessages.WM_KEYDOWN)
            {
                Keys key = (Keys)m.WParam;
                switch (key)
                {
                    case Keys.Left:
                        MessageBox.Show("Left");
                        return true;
                    case Keys.Right:
                        MessageBox.Show("Right");
                        return true;
                }
            }
            return false;
        }
    }
