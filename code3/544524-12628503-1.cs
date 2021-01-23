    public class ProfanityResult
    {
        public bool Profane { get; set; }
        public List<string> ProfanityWords { get; set; }
    }
    public ProfanityResult containsProfanity(string checkStr)
