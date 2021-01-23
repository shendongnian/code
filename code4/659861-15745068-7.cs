    You should write some unit tests to see that your code works correctly. But this quick test verifies the basic idea:
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime(2011, 6, 29);
            ushort dosDateTime = dateTime.ToDosDateTime();
            Console.WriteLine(dosDateTime);     // Prints: 16093
            Console.ReadLine();
        }
