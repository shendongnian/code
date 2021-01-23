    public class Form1 : Form {
        public Form1() {
           InitializeComponent();
        }
        protected override void WndProc(ref Message m){
          if(m.Msg == 0x4a)//WM_COPYDATA
          {
             COPYDATASTRUCT data = (COPYDATASTRUCT) m.GetLParam(typeof(COPYDATASTRUCT));
                if (data.dwData.ToInt32() == 123456)//Check if this is sent from your Console
                {
                    Color c = (Color)Marshal.PtrToStructure(data.lpData, typeof(Color));
                    yourButton.BackColor = c;
                    return;
                }
          }
          base.WndProc(ref m);
        }
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbSize;
            public IntPtr lpData;
        } 
    }
