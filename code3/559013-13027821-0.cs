        public Form1()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    int n = getButtonNumber((Button)c);
                    if (n <= 10)
                        c.Text = n.ToString();
                    c.Click += new EventHandler(c_Click);
                }
            }
            button11.Text = "<-"; button12.Text = "OK";
        }
        void c_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                int n = Convert.ToInt16( b.Text);
                digitButtonClick(n);
            }
        }
        private void digitButtonClick(int n)
        {
            byte vkInt = (byte)(0x30 + n);
            dateTimePicker1.Focus();
            keybd_event(vkInt, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(vkInt, 0, KEYEVENTF_KEYUP, 0);
        }
