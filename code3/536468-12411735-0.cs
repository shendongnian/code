    public Point Location
    {
      get
      {
        return new Point(Left, Top);
      }
      set
      {
        Left = value.X;
        Top = value.Y;
      }
    }
