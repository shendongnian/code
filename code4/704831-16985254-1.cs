    class RectangleSquare: Square<TFigure>
    {
      public RectangleSquare() : base (new Rectangle(){Height = 1, Width = 2})
      {
      }
      public override float GetStereotypeSide(Rectangle stereotype)
      {
         return stereotype.Height*stereotype.Width;
      }
    }
