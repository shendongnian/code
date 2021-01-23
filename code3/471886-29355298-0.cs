    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new ClientA("Adam", 68);
            var b = new ClientB("Bob", 1.75);
            var c = new ClientC("Cheryl", 54.4, 1.65);
            Console.WriteLine("{0} is {1:0.0} lbs.", a.Name, a.WeightPounds());
            Console.WriteLine("{0} is {1:0.0} inches tall.", b.Name, b.HeightInches());
            Console.WriteLine("{0} is {1:0.0} lbs and {2:0.0} inches.", c.Name, c.WeightPounds(), c.HeightInches());
            Console.ReadLine();
        }
    }
    public class Client
    {
        public string Name { get; set; }
        public Client(string name)
        {
            Name = name;
        }
    }
    public interface IWeight
    {
        double Weight { get; set; }
    }
    public interface IHeight
    {
        double Height { get; set; }
    }
    public class ClientA : Client, IWeight
    {
        public double Weight { get; set; }
        public ClientA(string name, double weight) : base(name)
        {
            Weight = weight;
        }
    }
    public class ClientB : Client, IHeight
    {
        public double Height { get; set; }
        public ClientB(string name, double height) : base(name)
        {
            Height = height;
        }
    }
    public class ClientC : Client, IWeight, IHeight
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public ClientC(string name, double weight, double height) : base(name)
        {
            Weight = weight;
            Height = height;
        }
    }
    public static class ClientExt
    {
        public static double HeightInches(this IHeight client)
        {
            return client.Height * 39.3700787;
        }
        public static double WeightPounds(this IWeight client)
        {
            return client.Weight * 2.20462262;
        }
    }
