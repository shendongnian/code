    public abstract class MediaBase
    {
        public String Title { get; set; }
        public Int32 Id { get; set; }
    }
    public sealed class Book : MediaBase
    {
        public String Author { get; set; }
        public Int32 Pages { get; set; }
    }
    public sealed class MovieDvd : MediaBase
    {
        public String Director { get; set; }
        public Int32 Length { get; set; }
    }
    public sealed class GameDvd : MediaBase
    {
        public Int32 NumberOfPlayers { get; set; }
    }
