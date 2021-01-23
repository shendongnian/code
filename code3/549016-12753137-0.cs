    public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseHover += new EventHandler(pictureBox1_MouseHover);
        }
        void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.Cursor = Cursors.Cross;
        }
