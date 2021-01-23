    class RectangleSquare: Square<Rectangle>
    {
      public RectangleSquare() : base (new Rectangle(){Height = 1, Width = 2})
      {
      }
      public override float GetStereotypeSide(Rectangle stereotype)
      {
         return stereotype.Height*stereotype.Width;
      }
    }
