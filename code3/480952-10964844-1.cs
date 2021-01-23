    private void glControl1_MouseMove(object sender, MouseEventArgs e)
    {
        if(MouseButtons.HasFlag(MouseButtons.Middle))
        {
            int dx = e.X - _mousePos.X;
            int dy = e.Y - _mousePos.Y;
            _viewRect.X -= dx * (_viewRect.Width / glControl1.Width);
            _viewRect.Y -= dy * (_viewRect.Height / glControl1.Height);
            _mousePos = e.Location;
            UpdateView();
        }
    }
