    void button1_Click(object sender, EventArgs e) {
      while (flowLayoutPanel1.Controls.Count > 0) {
        flowLayoutPanel1.Controls[0].Dispose();
      }
      for (int i = 0; i < textBox1.Text.Length; ++i) {
        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile(string.Format(@"c:\obrazki\{0}.jpg",textBox1.Text[i]));
        flowLayoutPanel1.Controls.Add(pb);
      }
    }
