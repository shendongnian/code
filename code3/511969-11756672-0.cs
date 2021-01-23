    private void button1_Click(object sender, EventArgs e)
        {
            PictureBox p =new PictureBox();
            p.ImageLocation = ofdFoto.FileName.ToString();
            p.Location = new Point(100, 100);
            this.Controls.Add(p);
        }
