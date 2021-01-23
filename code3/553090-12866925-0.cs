    [ServiceContract]
    public interface ICalculator
    {
      [OperationContract]
      uint Divide(uint numerator, uint denominator);
    }
    static class Program
    {
      // Wrap those Begin/End methods into a Task-based API.
      public static Task<uint> DivideAsyncTask(this CalculatorClient client,
          uint numerator, uint denominator)
      {
        return Task<uint>.Factory.FromAsync(client.BeginDivide, client.EndDivide,
            numerator, denominator, null);
      }
      static async Task CallCalculator()
      {
        var proxy = new CalculatorClient();
        var task = proxy.DivideAsyncTask(10, 5);
        var result = await task;
        Console.WriteLine("Result: " + result);
      }
 
      static void Main(string[] args)
      {
        try
        {
          CallCalculator().Wait();
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine(ex);
        }
 
        Console.ReadKey();
      }
    }
