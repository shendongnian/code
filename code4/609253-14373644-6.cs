    public enum AuthourType
    {
        Novelist,
        Other
    }
    public interface IAuthor
    {
        string Name { get; set; }
        AuthourType Type { get; set; }
    }
    public class  Novelist : IAuthor
    {
        public string Name { get; set; }
        public AuthourType Type { get; set; }
    }
