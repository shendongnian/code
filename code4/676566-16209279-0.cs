    void CreateRectangle()
    {
      int TallestRectangle = 0;
      int PrevRecY = 0;
      Pen pen = new Pen(Color.Black);
      Graphics graphic = this.CreateGraphics();
      foreach (Rectangle rect in rectangleCollection)
      {
        if (rect.Height > TallestRectangle)
          TallestRectangle = rect.Height;
      }
      foreach (Rectangle rect in rectangleCollection)
      {
        graphic.DrawRectangle(pen, new Rectangle(rect.X + PrevRecY, (TallestRectangle - rect.Height), rect.Width, rect.Height));
        PrevRecY += rect.Width; // note the +=
      }
    }
