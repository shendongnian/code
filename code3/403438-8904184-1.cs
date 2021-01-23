    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class CueComboBox : ComboBox {
        private string mCue;
        public string Cue {
            get { return mCue; }
            set {
                mCue = value;
                updateCue();
            }
        }
        private void updateCue() {
            if (this.IsHandleCreated && mCue != null) {
                SendMessage(this.Handle, 0x1703, (IntPtr)0, mCue);
            }
        }
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            updateCue();
        }
        // P/Invoke
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
    }
