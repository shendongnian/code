    public sealed class MazeMap : MapDisplay {
      protected override string[]   Board { get { return _board; } }
      string[] _board = new string[] {
        ".............|.........|.......|.........|.............",
           /* many similar lines omitted */
        ".............................|.......|.....|..........."
      };
      public override bool  IsPassable(ICoordsUser coords) { 
        return IsOnBoard(coords)  &&  this[coords].Elevation == 0; 
      }
      public override IMapGridHex this[ICoordsCanon coords] { get {return this[coords.User];} }
      public override IMapGridHex this[ICoordsUser  coords] { get {
        return new GridHex(Board[coords.Y][coords.X], coords);
      } }
      public struct GridHex : IMapGridHex {
        internal static MapDisplay MyBoard { get; set; }
        public GridHex(char value, ICoordsUser coords) : this() { Value = value; Coords = coords; }
        IBoard<IGridHex> IGridHex.Board           { get { return MyBoard; } }
        public IBoard<IMapGridHex> Board          { get { return MyBoard; } }
        public ICoordsUser         Coords         { get; private set; }
        public int                 Elevation      { get { return Value == '.' ? 0 : 1; } }
        public int                 ElevationASL   { get { return Elevation * 10;   } }
        public int                 HeightObserver { get { return ElevationASL + 1; } }
        public int                 HeightTarget   { get { return ElevationASL + 1; } }
        public int                 HeightTerrain  { get { return ElevationASL + (Value == '.' ? 0 : 10); } }
        public char                Value          { get; private set; }
        public IEnumerable<NeighbourHex> GetNeighbours() {
          var @this = this;
          return NeighbourHex.GetNeighbours(@this).Where(n=>@this.Board.IsOnBoard(n.Hex.Coords));
        }
      }
    }
