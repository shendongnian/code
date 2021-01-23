    class MockKeyboardTest : Form
    {
        public MockKeyboardTest()
        {
            InitializeComponent();
            PressedKey = Keys.BrowserBack;
        }
        public void ShowDialog(KeyboardTask kkt)
        {
            Keyboard = kkt;
            base.ShowDialog();
        }
        public void InitializeComponent()
        {
            this.Shown += MockKeyboardTest_Shown;
            KeyboardTestTextbox.AcceptsTab = true;
            KeyboardTestTextbox.Location = new Point(2, 22);
            KeyboardTestTextbox.MaxLength = 50;
            KeyboardTestTextbox.Multiline = true;
            KeyboardTestTextbox.Size = new Size(195, 25);
            KeyboardTestTextbox.KeyDown += this.KeyboardTestTextbox_KeyDown;
            Controls.Add(KeyboardTestTextbox);
        }
        void MockKeyboardTest_Shown(object sender, System.EventArgs e)
        {
            Keyboard.PerformTask();
        }
        private void KeyboardTestTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKey = e.KeyData;
            this.DialogResult = DialogResult.OK;
        }
        private TextBox KeyboardTestTextbox = new TextBox();
        private KeyboardTask Keyboard;
        public Keys PressedKey;
    }
