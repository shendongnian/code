        Color highLite = Color.Black;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                Button b = new Button();
                b.Text = i.ToString();
                b.Tag = null;
                b.Click += b_Click;
                flowLayoutPanel1.Controls.Add(b);
            }
        }
        void b_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b == null)
                return;
            b.BackColor = highLite;
            // clear backcolors
            foreach (Control c in flowLayoutPanel1.Controls)
                if (c != b)
                    c.BackColor = SystemColors.Control;
        }
