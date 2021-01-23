    private void button1_Click(object sender, EventArgs e)
    {
        for (int iter = 0; iter < 500; iter++)
        {
            pictureBox1.Location = new Point(pictureBox1.Left + 1, pictureBox1.Top + 1);
            Application.DoEvents();
            System.Threading.Thread.Sleep(30);
        }
    }
