    public class Skill
    { 
        public string Name { get; set; }
        public int Value { get; set; } 
    }
    public class Player
    {
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
