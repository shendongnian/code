    public partial class Form1 : Form {
        globalKeyboardHook globalKeyboardHook = new globalKeyboardHook();
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            globalKeyboardHook.HookedKeys.Add(Keys.Pause);
            globalKeyboardHook.KeyDown += new KeyEventHandler(globalKeyboardHook_KeyDown);
            globalKeyboardHook.KeyUp += new KeyEventHandler(globalKeyboardHook_KeyUp);
        }
        void globalKeyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            // remove this when you want to run invisible
            lstLog.Items.Add("Up\t" + e.KeyCode.ToString());
    
            // this prevents the key from bubbling up in other programs
            e.Handled = true;
        }
        void globalKeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            // remove this when you want to run without visible window
            lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
            // this prevents the key from bubbling up in other programs
            e.Handled = true;
        }
    }
