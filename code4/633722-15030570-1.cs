        private int X = 0;
        private int Y = 0;
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Position = new Point(X, Y);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor.Position.X < this.Bounds.X + 50 )
                X = Cursor.Position.X + 20;
            else
                X = Cursor.Position.X - 20;
            if (Cursor.Position.Y < this.Bounds.Y + 50)
                Y = Cursor.Position.Y + 20;
            else
                Y = Cursor.Position.Y - 20;           
        }
