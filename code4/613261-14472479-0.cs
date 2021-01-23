    var img = new Bitmap(open.FileName);
    using (Graphics g = Graphics.FromImage(img))
    {
        g.FillRectangle(Brushes.Red, 0, 0, 20, 50);  
    }
    pictureBox1.Image = img;
