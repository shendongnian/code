    class Program
    {
        static void Main(string[] args)
        {
            float charge = ParkingCharges.Charge(100);
            Console.WriteLine(charge.ToString("000.00"));
            Console.ReadKey();
        }
    }
