    public class CD
    {
        private readonly List<Track> _tracks = new List<Track>();
        public CD(string artist, string title)
        {
            Artist = artist;
            Title = title;
        }
        public string Artist { get; private set; }
        public string Title { get; private set; }
        public  IEnumerable<Track> Tracks
        {
            get { return _tracks; }
        } 
        public void AddTrack(Track track)
        {
            _tracks.Add(track);
        }
        public CD WithTrack(string title, TimeSpan length)
        {
            AddTrack(new Track(Artist, title, length));
            return this;
        }
    }
