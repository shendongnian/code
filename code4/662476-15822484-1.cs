        KeyboardHook hook = new KeyboardHook();
        public Form1()
        {
            InitializeComponent();
            // register the event that is fired after the key press.
            hook.KeyPressed +=
            new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt, Keys.F12);
        }
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == global::ModifierKeys.Control && e.Key == Keys.A)
            {
                 //Some code here when hotkey is pressed.
            }
        }
