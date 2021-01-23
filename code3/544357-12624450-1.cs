    protected override OnMouseMove(MouseMoveEventArgs e)
    {
       bool needToRedraw = false;
    
       using (Graphics g = CreateGraphics())
       {
          foreach (GraphicalObject obj in Objects)
          {
             if (!obj.IsVisible)
                   continue;
    
             Rectangle rect = obj.GetBounds(e.Graphics);
             if (rect.Contains(e.Location))
             {
                if (!obj.IsFocused)
                {
                   obj.IsFocused = true;
                   needToRedraw = true;
                }
             }
             else
             {
                if (obj.IsFocused)
                {
                   obj.IsFocused = false;
                   needToRedraw = true;
                }
             }
    
             obj.Draw(e.Graphics);
          }
       }
    
       if (needToRedraw)
          Invalidate();
    }
