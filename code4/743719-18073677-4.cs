    public class GreatAlbum: Album {
        private Boolean m_IsGreat;  
        public override int AlbumId {
          get {
            if (m_IsGreat) 
              return base.AlbumId
            else
              return 0; 
          } 
          set {
            m_IsGreat = (value != 0);
            base.AlbumId = value;
          }
        }
      ... 
    }
