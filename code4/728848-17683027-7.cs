    public class BusinessCalculator : ICalculator {
      private BusinessData CalculateMoney() {
        // snip
      }
      public decimal CalculateCents() {
        return CalculateMoney().Money * 100d;
      }
    }
    
    public BusinessController : IController {
      public void DoAnAction() {
        Console.WriteLine(new BusinessCalculator().CalculateCents());
      }
    }
