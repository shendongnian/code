    public class Cube {
      private Point _center;
      public Point CopyCenter() { return _center.Clone(); }
      public double CenterX { get { return _center.X; } set { _center.X = value; } }
      public double CenterY { get { return _center.Y; } set { _center.Y = value; } }
      public double CenterZ { get { return _center.Z; } set { _center.Z = value; } }
    }
