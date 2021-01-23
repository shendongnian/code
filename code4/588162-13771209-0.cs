    public class MediaBase
    {
        public String Title { get; set; }
    }
    public sealed class Book : MediaBase
    {
    }
    public sealed class MovieDvd : MediaBase
    {
    }
    public sealed class GameDvd : MediaBase
    {
    }
