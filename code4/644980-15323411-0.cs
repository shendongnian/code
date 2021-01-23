    private void Form1_Load(object sender, EventArgs e)
    {
        this.Resize += Form1_Resize;
    }
    private void Form1_Resize(object sender, EventArgs e)
    {
        pictureBox1.Left = (this.Width - pictureBox1.Width)/2;
        pictureBox1.Top = (this.Height - pictureBox1.Height)/2;
    }
