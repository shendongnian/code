    private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Left)
        return;
      _IsSelecting = true;
      _StartPoint = tableLayoutPanel1.PointToScreen(e.Location);
      _FrameRect = new Rectangle(_StartPoint, Size.Empty);
    }
    private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e) {
      if (!_IsSelecting)
        return;
      ControlPaint.DrawReversibleFrame(_FrameRect, Color.Black, FrameStyle.Dashed);    
      Point pt = tableLayoutPanel1.PointToScreen(e.Location);
      _FrameRect.Width = pt.X - _StartPoint.X;
      _FrameRect.Height = pt.Y - _StartPoint.Y;
      ControlPaint.DrawReversibleFrame(_FrameRect, Color.Black, FrameStyle.Dashed);
    }
