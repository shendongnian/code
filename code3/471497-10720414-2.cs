    public class CalculatorConfig
    {
          public double param1 {get;set;}
          public double param2 {get;set;}
          
          public CalculatorConfig()
          {
              InitParams();
          }
          private void InitParams()
          {
              param1 = 1.0;
              param2 = 2.0;
          }
    }
