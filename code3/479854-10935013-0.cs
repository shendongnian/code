    public class Character : BaseEntity
    {
        public string Name { get; set; }
        public bool IsEvil { get; set; }
        public virtual ICollection<Videogame> Videogames { get; set; } 
    }
    public class Videogame : BaseEntity 
    {
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
        public Author Author { get; set; }
    }
