    class Program
    {
        static void Main()
        {
            // Create a client.
            CalculatorInstanceClient client = new CalculatorInstanceClient();
            string instanceMode = client.GetInstanceContextMode();
            Console.WriteLine("InstanceContextMode: {0}", instanceMode);
            Console.WriteLine("client1's turn");
            Console.WriteLine("2 + 2 = {0}", client.Add(2, 2).ToString());
            Console.WriteLine("3 - 1 = {0}", client.Subtract(3, 1).ToString());
            Console.WriteLine("number of operations = {0}", client.GetOperationCount().ToString());
    
            // Create a second client.
            CalculatorInstanceClient client2 = new CalculatorInstanceClient();
    
            Console.WriteLine("client2's turn");
            Console.WriteLine("2 + 2 = {0}", client2.Add(2, 2).ToString());
            Console.WriteLine("3 - 1 = {0}", client2.Subtract(3, 1).ToString());
            Console.WriteLine("number of operations = {0}", client2.GetOperationCount().ToString());
    
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
