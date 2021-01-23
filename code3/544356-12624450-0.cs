    protected override void OnPaint(PaintEventArgs e)
    {
       foreach (GraphicalObject obj in Objects)
       {
          if (!obj.IsVisible)
                continue;
    
          Rectangle rect = obj.GetBounds(e.Graphics);
          if (!rect.Intersects(e.ClipRectangle))
             continue;
    
          obj.Draw(e.Graphics);
       }
    }
    
