    try
    {
     MyServiceClient client = new MyServiceClient();
     Console.WriteLine(client.GetOrders().First().Date_Accepted.ToString());
     client.Close();
     Console.ReadLine();
    }
    catch (Exception ex)
    {
     Console.WriteLine(ex);
    }
