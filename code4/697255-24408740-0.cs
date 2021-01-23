        private Point _Offset = Point.Empty;
        private void ctrlToMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _Offset = new Point(e.X, e.Y);
            }
        }
        private void ctrlToMove_MouseUp(object sender, MouseEventArgs e)
        {
            _Offset = Point.Empty;
        }
        private void ctrlToMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Offset != Point.Empty)
            {
                Point newlocation = ctrlToMove.Location;
                newlocation.X += e.X - _Offset.X;
                newlocation.Y += e.Y - _Offset.Y;
                ctrlToMove.Location = newlocation;
            }
        }
