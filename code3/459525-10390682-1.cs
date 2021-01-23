    [Serializable]
    public enum DogColor
    {
        Brown,
        Black,
        Mottled
    }
    [Serializable]
    public class Dog
    {
        public String Name
        {
            get; set;
        }
        public DogColor Color
        {
            get;set;
        }
        public override String ToString()
        {
            return String.Format("Dog: {0}/{1}", Name, Color);
        }
    }
