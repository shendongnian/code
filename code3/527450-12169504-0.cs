    public struct Position {
      public long PositionX { get; private set; }
      public long PositionY { get; private set; }
      public CompassPoint CompassPoint { get; private set; }
      public Position(long x, long y, CompassPoint compass) {
        PositionX = x;
        PositionY = y;
        CompassPoint = compass;
      }
    }
