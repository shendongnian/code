        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new ThreadStart(YourFunction).BeginInvoke(null, null);
        }
        private void YourFunction()
        {
            Thread.Sleep(5000);
            MessageBox.Show("YourFunction called!");
        }
