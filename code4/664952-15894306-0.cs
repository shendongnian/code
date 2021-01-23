    public class Album
    {
        public Album(string album, string artist)
        {
            albumName = album;
            artistName = artist;
        }
    
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public override string ToString() 
        {
            return string.Format("{0} {1}", AlbumName, ArtistName);
        }
    }
