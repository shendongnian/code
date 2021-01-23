    static void Main(string[] args)
        {
            // Send initial message to start the workflow service
            Console.WriteLine("Sending start message");
            ServiceClient proxy = new ServiceClient();
            string orderId = proxy.StartOrder("Kim Abercrombie");
            // The workflow service is now waiting for the second message to be sent
            Console.WriteLine("Workflow service is idle...");
            Console.WriteLine("Press [ENTER] to send an add item message to reactivate the workflow service...");
            Console.ReadLine();
            // Send the second message
            Console.WriteLine("Sending add item message");
            AddItem item = new AddItem();
            item.p_itemId = "Zune H";
            item.p_orderId = orderId;
            string orderResult = proxy.AddItem(item);
            Console.WriteLine("Service returned: " + orderResult);
        }
