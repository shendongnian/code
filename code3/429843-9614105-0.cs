    [DelimitedRecord(",")]
    public class Customer
    {
      public int CustId;	
      public string Name;
      public decimal Balance;
    }
    FileHelperEngine engine = new FileHelperEngine(typeof(Customer));
    Customer[] res = engine.ReadFile("FileIn.txt") as Customer[];
    engine.WriteFile("FileOut.txt", res);
