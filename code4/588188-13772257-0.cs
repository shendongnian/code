    public class Media
    {
        public enum MediaType
        {
            DVD,
            Bluray
        }
        public MediaType TypeOfMedia { get; set; }
        public string Director { get; set; }
        public string Title { get; set; }
        public Media(string Title, string Director, MediaType TypeOfMedia)
        {
            this.TypeOfMedia = TypeOfMedia;
            this.Director = Director;
            this.Title = Title;
        }
    }
