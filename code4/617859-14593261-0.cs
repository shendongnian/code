        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(@"C:\avatar63.jpg");
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Brushes.Red, 5), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }
            bitmap.Save(@"C:\avatar63New.jpg");
        }
