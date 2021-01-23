    private void SetDayBoxSize()
    {
      int bottom = this.Height;
    
      while (HitTest(25, dayTop).HitArea != HitArea.Date &&
             HitTest(25, dayTop).HitArea != HitArea.PrevMonthDate) dayTop++;
    
      while (HitTest(25, bottom).HitArea != HitArea.Date &&
        HitTest(25, bottom).HitArea != HitArea.NextMonthDate) bottom--;
    
      dayBox = new Rectangle();
      dayBox.Size = new Size(this.Width / 7, (bottom - dayTop) / 6);
    }
