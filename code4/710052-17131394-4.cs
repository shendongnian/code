    public class Order : Searchable
    {
       public string OrderNumber {get; set;}
       public decimal OrderWeight {get; set;}
       public IEnumerable<ParamInfo> Params 
       {  
          get 
          { 
              return new List<ParamInfo> 
              {
                  new ParamInfo(typeof(TextBox), typeof(string), "Enter value", true),
                  new ParamInfo(typeof(TextBox), typeof(decimal), 0, true),
                  new ParamInfo(typeof(TextBox), typeof(decimal), 0, true)
              }
          }  
       }
       public Func<bool> Predicate
       {  
          get 
          { 
              return () => OrderNumber.Contains("ORDER-01") 
                        && OrderWeight >= 100 
                        && OrderWeight <= 200; //and so on, you get the idea.
          }  
       }
