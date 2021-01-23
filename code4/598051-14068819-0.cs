    public partial class HotkeyForm : Form {
        public HotkeyForm() {
            InitializeComponent();
            RegisterHotKey(this.Handle, 0, 0, (int)Keys.Subtract);
            
            
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x0312) {
                switch (m.WParam.ToInt32()) {
                    case 0: //numpad minus.
                        //Environment.Exit(0);
                        Console.WriteLine("FORM HOTKEY");
                        break;
                }
            }
            base.WndProc(ref m);
        }
    }
