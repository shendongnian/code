        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = Graphics.FromImage(pictureBox1.Image);
            gfx.DrawLine(new Pen(Color.Red, 5), new Point(10, 10), new Point(20, 20));
            gfx.DrawLine(new Pen(Color.Red, 5), new Point(20, 10), new Point(10, 20));
            pictureBox1.Image.Save("test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox1.Refresh(); // The file will be correct without this, but the update will not be shown
        }
