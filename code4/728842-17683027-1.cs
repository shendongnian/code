    public class BusinessCalculator : ICalculator {
      public IResult CalculateMoney() {
        // snip
      }
      public decimal CalculateCents() {
        return CalculateMoney() * 100d;
      }
    }
    
    public BusinessController : IController {
      public void DoAnAction() {
        Console.WriteLine(new BusinessCalculator().CalculateCents());
      }
    }
