    public interface Human
    {
        bool Male { get; }
    }
    public class Man : Human
    {
        public bool HasABeard { get { return true; } }
        public bool IsMale { get { return true; } }
    }
    public class Woman : Human
    {
        public bool IsMale { get { return false; } }
        public List<Pair<Shoe>> Shoes { get; set; }
    }
