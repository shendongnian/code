    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class LegacyListBox : ListBox
    {
        private const int LB_ADDSTRING = 0x180;
        public LegacyListBox() { }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == LB_ADDSTRING)
            {
                Items.Add(Marshal.PtrToStringUni(m.LParam));
                // prevent base class from handling this message
                return;
            }
            base.WndProc(ref m);
        }
    }
