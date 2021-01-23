    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
          //compare ARGB values
          if (this.BackColor.ToArgb() == Color.White.ToArgb())
          {
               this.BackColor = Color.Yellow;
    
          }
          else
          {
               this.BackColor = Color.White;
          }
          base.OnMouseDoubleClick(e);
    }
