    void button1_Click(object sender, EventArgs e) {
      img = = Image.FromFile("C:\\Users\\HDAdmin\\Pictures\\humanbody\\effect2.png");
      this.Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e) {
      e.Graphics.Clear(this.BackColor);
      if (img != null) {
        e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
      }
      //Draw test shape:
      e.Graphics.DrawRectangle(Pens.Red, new Rectangle(10, 10, 20, 60));
    }
