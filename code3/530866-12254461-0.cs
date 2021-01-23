    public class Car
    {
        public abstract string Manufacturer { get; }
    }
    public class Odyssey : Car
    {
        public override string Manufacturer
        {
             get 
             {
                 return "Honda";
             }
        }
    }
    public class Camry : Car
    {
        public override string Manufacturer
        {
             get 
             {
                 return "Toyota";
             }
        }
    }
