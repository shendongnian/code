    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();
        public Form1()
        {
            InitializeComponent();
            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            
            // register the CONTROL + ALT + F12 combination as hot key.
            // You can change this.
            hook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt, Keys.F12);
        }
        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // Trigger your function
            MinimiseToTray(true);
        }
        private void MinimiseToTray(bool shortCutPressed)
        {
            // ... Your code
        }
    }
