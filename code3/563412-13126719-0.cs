        private void Form1_Load(object sender, EventArgs e)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                Thread.Sleep(1);
                pixels.Add(new Pixel(pictureBox1));
            }
        }
