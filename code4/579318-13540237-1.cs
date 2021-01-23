    public abstract class Car
    {
        public string Name { get; private set; }
        protected Car(string name)
        {
            this.Name name;
        }
    }
    public class Mustang : Car
    {
        public Mustang() : base("Mustang")
        {
        }
    }
