    void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (var font = new Font("Arial", 14))
        {
            const string pictureName = "Picture.jpg";
            var textPosition = new Point(10, 10);
            //Drawing logic begins here.
            var size = e.Graphics.MeasureString(pictureName, font);
            var rect = new RectangleF(textPosition.X, textPosition.Y, size.Width, size.Height);
            //Filling a rectangle before drawing the string.
            e.Graphics.FillRectangle(Brushes.Red, rect);
            e.Graphics.DrawString(pictureName, font, Brushes.Green, textPosition);
        }
    }
