        public Form1()
        {
            InitializeComponent();
            _form2 = new Form2();
            _form2.Show(this);
            this.Closed += Form1Closed;
            _form2.Closed += Form2Closed;
        }
        private void Form1Closed(object sender, EventArgs eventArgs)
        {
            form1IsClosed = true;
            TryExitApplication();
        }
        private void Form2Closed(object sender, EventArgs eventArgs)
        {
            _form2IsClosed = true;
            TryExitApplication();
        }
        private void TryExitApplication()
        {
            if (form1IsClosed && _form2IsClosed)
            {
                Application.Exit();
            }
        }
