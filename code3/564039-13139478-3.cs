    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
     
    namespace Test
    {
        public class Test
        {
            private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
            private const int APPCOMMAND_VOLUME_UP = 0xA0000;
            private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
            private const int WM_APPCOMMAND = 0x319;
     
            [DllImport("user32.dll")]
            public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
                IntPtr wParam, IntPtr lParam);
     
            private void Mute()
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                    (IntPtr)APPCOMMAND_VOLUME_MUTE);
            }
     
            private void VolDown()
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                    (IntPtr)APPCOMMAND_VOLUME_DOWN);
            }
     
            private void VolUp()
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                    (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }
    }
