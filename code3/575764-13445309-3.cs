    public class OperatorType
    {
       public static OperatorType GreaterOrEqual = new OperatorType(">=", "GreaterOrEqual");
       // ...
       string symbol;
       string name;
       private OperatorType(string symbol, string name)
       {
           this.symbol = symbol;
           this.name = name;
       }
    }
