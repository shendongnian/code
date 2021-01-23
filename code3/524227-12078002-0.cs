    public class MyFileInfoWrapper : IComparable<MyFileInfoWrapper>,IComparable
    {
      public MyFileInfoWrapper( FileInfo fi )
      {
        // your implementation here
        throw new NotImplementedException() ;
      }
      
      public int    Hi         { get ; private set ; }
      public int    Lo         { get ; private set ; }
      public string Extension  { get ; private set ; }
      
      public FileInfo FileInfo { get ; private set ; }
      
      public int CompareTo( MyFileInfoWrapper other )
      {
        int cc ;
        if      ( other   == null     ) cc = -1 ;
        else if ( this.Hi <  other.Hi ) cc = -1 ;
        else if ( this.Hi >  other.Hi ) cc = +1 ;
        else if ( this.Lo <  other.Lo ) cc = -1 ;
        else if ( this.Lo >  other.Lo ) cc = +1 ;
        else                            cc = string.Compare( this.Extension , other.Extension , StringComparison.InvariantCultureIgnoreCase ) ;
        return cc ;
      }
      
      public int CompareTo( object obj )
      {
        int cc ;
        if      ( obj == null              ) cc = -1 ;
        else if ( obj is MyFileInfoWrapper ) cc = CompareTo( (MyFileInfoWrapper) obj ) ;
        else throw new ArgumentException("'obj' is not a 'MyFileInfoWrapper' type.", "obj") ;
        return cc ;
      }
      
    }
