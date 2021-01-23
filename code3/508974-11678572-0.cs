        public WindowsConsoleForm1();
            try
            {
                InitializeComponent();
                textBox1.Text = Application.UserAppDataRegistry.GetValue("example").ToString();
            }
            catch { }
