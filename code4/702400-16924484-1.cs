    class Program
    {
        static void Main(string[] args)
        {
                /// Displays '06 04 13'
            Console.WriteLine(string.Format("{0:MM/dd/yy}", System.DateTime.Now));
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                /// Displays '06/04/13'
            Console.WriteLine(string.Format("{0:MM/dd/yy}", System.DateTime.Now));
            Console.ReadLine();
        }
    }
