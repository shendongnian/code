    class Program
    {
        static void Main( )
        {
            int Number = 10;
            Console.WriteLine(Number.ToString());
            Customer cc = new Customer();
            cc.FirstName = "Rakibuz";
            cc.LastName = "Sultan";
            Console.WriteLine(Convert.ToString(cc));
        }
    }
    public class Customer
    {
        public string FirstName;
        public string LastName;
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
