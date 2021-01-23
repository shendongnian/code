    public class Request()
    {
              public int RequestId    { get; set; }
              public RequestCost RequestCost { get; set; }
    }
    
    public class RequestCost ()
    {
              public int RequestId    { get; set; }
              public CostType CostType { get; set; }
              public CurrencyUnit CurrencyUnit{ get; set; }
    }
    
      var items = context.dbRequest.include("RequestCost")
                                       .include("RequestCost.CurrencyUnit")
                                      .include("RequestCost.CostType").ToList();
