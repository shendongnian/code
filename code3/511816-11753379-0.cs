    private PictureBox pictureBox1 = new PictureBox();
    
    pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
    
    private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
       GetPixel_Example(e) ;
    }
