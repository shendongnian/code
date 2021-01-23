    public Form1()
    {
      InitializeComponent();
      pictureBox1.MouseHover += new EventHandler(PictureBox1_MouseHover);
    }
    void pictureBox1_MouseHover(object sender, EventArgs e)
    {
      this.PictureBox1.Cursor = Cursors.Cross;
    }
