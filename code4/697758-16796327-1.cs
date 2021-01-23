    public class Track
    {
        public Track(string artist, string title, TimeSpan length)
        {
            Artist = artist;
            Title = title;
            Length = length;
        }
        public string Artist { get; set; }
        public string Title { get; private set; }
        public TimeSpan Length { get; private set; }
    }
