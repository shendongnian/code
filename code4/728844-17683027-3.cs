    public interface IResult {
      public decimal Money { get; set; }
    }
    
    public class BusinessCalculator : ICalculator {
      public IResult CalculateMoney() {
        // snip
      }
    }
    
    public BusinessController : IController {
      public void DoAnAction() {
        Console.WriteLine(new BusinessCalculator().CalculateMoney().Money * 100d);
      }
    }
