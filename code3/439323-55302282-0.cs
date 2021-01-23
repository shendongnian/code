    private void Form1_Load(object sender, EventArgs e)
            {
                _originalClip = Cursor.Clip;
            }
    
            private void pb_MouseMove(object sender, MouseEventArgs e)
            {
                PictureBox pb = (PictureBox)sender;
                if (e.Button == MouseButtons.Left)
                {
                    Size sz = new Size(panel1.RectangleToScreen(panel1.ClientRectangle).Width - (pb.Width), panel1.RectangleToScreen(panel1.ClientRectangle).Height - (pb.Height));
                    Point loc = new Point(panel1.RectangleToScreen(panel1.ClientRectangle).X + (pb.Width / 2), panel1.RectangleToScreen(panel1.ClientRectangle).Y + (pb.Height / 2));
                    Rectangle rct = new Rectangle(loc, sz);
                    Cursor.Clip = rct;
                    pb.Left += (e.X - x);
                    pb.Top += (e.Y - y);
                }
            }
            private void pb_MouseUp(object sender, MouseEventArgs e)
            {
                Cursor.Clip = _originalClip;
            }
