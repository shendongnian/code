        public Form1()
        {
            InitializeComponent();
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Click += HandleAllButtonClicks;
            }
        }
        private void HandleAllButtonClicks(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            TboxPrint.AppendText(String.Format("Button Clicked : Name = {0}, Text = {1}", btn.Name, btn.Text));
        }
