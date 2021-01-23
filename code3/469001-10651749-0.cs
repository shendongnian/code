    private void button1_Click(object sender, EventArgs e)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image;
            }
    
            private void TestForm12_Load(object sender, EventArgs e)
            {
                pictureBox1.Image = Image.FromFile("c:\\url.gif");
            }
