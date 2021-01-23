      public interface ICoordsUser {
        int             X         { get; }
        int             Y         { get; }
        IntVector2D     Vector    { get; set; }
        ICoordsCanon    Canon     { get; }
        //ICoordsUser     Clone();
        string          ToString();
        int             Range(ICoordsUser coords);
        IEnumerable<NeighbourCoords> GetNeighbours(Hexside hexsides);
      }
    
      public partial class Coords {
        int           ICoordsUser.X          { get { return VectorUser.X; } }
        int           ICoordsUser.Y          { get { return VectorUser.Y; } }
        IntVector2D   ICoordsUser.Vector     { get { return VectorUser;   }
                                               set { VectorUser=value;    } }
        ICoordsCanon  ICoordsUser.Canon      { get { return this;         } } 
        //ICoordsUser   ICoordsUser.Clone()    { return NewUserCoords(VectorUser); }
        string        ICoordsUser.ToString() { return VectorUser.ToString(); }
    
        IEnumerable<NeighbourCoords> ICoordsUser.GetNeighbours(Hexside hexsides) { 
          return GetNeighbours(hexsides); 
        }
        int ICoordsUser.Range(ICoordsUser coords) { return Range(coords.Canon); }
      }
    }
