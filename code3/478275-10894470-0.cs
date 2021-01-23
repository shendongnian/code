        Button b;
        public Form1()
        {
            InitializeComponent();
            b = new Button();
            b.Text = "Hover me";
            b.Top = 100;
            b.Left = 100;
            b.Size = new Size(80, 30);
            this.Controls.Add(b);
            b.MouseEnter += delegate(object sender, EventArgs e)
            {
                b.SetBounds(b.Left - 5, b.Top - 2, b.Width + 10, b.Height + 4);
            };
            b.MouseLeave += delegate(object sender, EventArgs e)
            {
                b.SetBounds(b.Left + 5, b.Top + 2, b.Width - 10, b.Height - 4);
            };
        }
