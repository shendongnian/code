    public interface BusinessData {
      public decimal Money { get; set; }
    }
    
    public class BusinessCalculator : ICalculator {
      public BusinessData CalculateMoney() {
        // snip
      }
    }
    
    public BusinessController : IController {
      public void DoAnAction() {
        var businessDA = new BusinessCalculator().CalculateMoney();
        Console.WriteLine(businessDA.Money * 100d);
      }
    }
