    public class Concrete : SomeInterface
    {
        private Concrete()
        {
            //instantiate other classes here
        }
        public string GetAString()
        {
            return string.Empty;
        }
        public static Concrete GetInstance()
        {
            return new Concrete();
        }
    }
    public class Wrapper : SomeInterface
    {
        public Wrapper()
        {
            this.concrete = Concrete.GetInstance();
        }
        Concrete concrete { get; set; }
        public string GetAString()
        {
            this.concrete.GetAString();
        }
    }
    public interface SomeInterface
    {
        string GetAString();
    }
