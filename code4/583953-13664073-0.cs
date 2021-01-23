        public class PlayList
        {
            [Key]
            public int ID { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
        
            public virtual IList<PlayListSong> PlaylistSongs { get; set; }
        }
    
        public class PlayListSong
        {
            [Key]
            public int ID { get; set; }
            public int PlayListID { get; set; }
            public int SongID { get; set; }
    
            public virtual PlayList Playlist { get; set; }
            public virtual Song Song { get; set; }
    
            public int NumberVotes { get; set; }
        }
    
        public class Song
        {
            [Key]
            public int ID { get; set; }
            public string Title { get; set; }
            public string SongArtURL { get; set; }
    
            //public virtual Artist Artist { get; set; }
            //public virtual Genre Genre { get; set; }
            public IList<PlayListSong> PlaylistSongs { get; set; }
           // public IList<Album> Albums { get; set; }
        }
