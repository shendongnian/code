    private Image img;
    public Form1() {
      InitializeComponent();
      button1.Click += button1_Click;
      pictureBox1.Paint += pictureBox1_Paint;
    }
    void button1_Click(object sender, EventArgs e) {
      img = = Image.FromFile("C:\\Users\\HDAdmin\\Pictures\\humanbody\\effect2.png");
      pictureBox1.Invalidate();
    }
    void pictureBox1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(pictureBox1.BackColor);
      if (img != null) {
        e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
        //Draw test shape:
        e.Graphics.DrawRectangle(Pens.Red, new Rectangle(10, 10, 20, 60));
      }
    }
