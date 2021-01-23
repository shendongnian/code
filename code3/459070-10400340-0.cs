    private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Left)
        return;
      _IsSelecting = true;
      _StartPoint = PointToScreen(e.Location);
      _StartPoint.Offset(tableLayoutPanel1.Location);  //  <-- here
      _FrameRect = new Rectangle(_StartPoint, Size.Empty);
    }
    private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e) {
      if (!_IsSelecting)
        return;
      ControlPaint.DrawReversibleFrame(_FrameRect, Color.Black, FrameStyle.Dashed);    
      Point pt = PointToScreen(e.Location);
      pt.Offset(tableLayoutPanel1.Location);  //  <-- here
      _FrameRect.Width = pt.X - _StartPoint.X;
      _FrameRect.Height = pt.Y - _StartPoint.Y;
      ControlPaint.DrawReversibleFrame(_FrameRect, Color.Black, FrameStyle.Dashed);
    }
