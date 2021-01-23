    public class Release{
      private Genre _genre=null;
      public Genre Genre{
        get{
          WriteLog((_genre == null).ToString());
          return _genre;
        }
        set{
          WriteLog((_genre == null).ToString());
          _genre = value;      
        }
      }
    }
