      public interface ICoordsCanon {
        int             X         { get; }
        int             Y         { get; }
        IntVector2D     Vector    { get; set; }
        ICoordsCustom   Custom    { get; }
        ICoordsUser     User      { get; }
        //ICoordsCanon    Clone();
        string          ToString();
        int             Range(ICoordsCanon coords);
        IEnumerable<NeighbourCoords> GetNeighbours(Hexside hexsides);
      }
      public partial class Coords {
        int             ICoordsCanon.X          { get { return VectorCanon.X; } }
        int             ICoordsCanon.Y          { get { return VectorCanon.Y; } }
        IntVector2D     ICoordsCanon.Vector     { get { return VectorCanon;   }
                                                  set { VectorCanon=value;    } }
        ICoordsUser     ICoordsCanon.User       { get { return this; } }
        ICoordsCustom   ICoordsCanon.Custom     { get { return this; } }
        //ICoordsCanon    ICoordsCanon.Clone()    { return NewCanonCoords(this.VectorCanon); }
        string          ICoordsCanon.ToString() { return VectorCanon.ToString(); }
    
        IEnumerable<NeighbourCoords> ICoordsCanon.GetNeighbours(Hexside hexsides) { 
          return GetNeighbours(hexsides); 
        }
        int ICoordsCanon.Range(ICoordsCanon coords) { return Range(coords); }
      }
