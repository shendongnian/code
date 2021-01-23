    public interface ICar
    {
        string Make { get; }
    }
    public class Malibu : ICar
    {
        public string Make { get { return "Chevrolet"; } }
    }
    public class Mustang : ICar
    {
        public string Make { get { return "Ford"; } }
    }
