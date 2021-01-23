    private void panel2_MouseMove(object sender, MouseEventArgs e)
    {
      if (isDragging) {
        mouseMoveX = e.X;
        mouseMoveY = e.Y;                               
        this.Invalidate();
      }
    }
