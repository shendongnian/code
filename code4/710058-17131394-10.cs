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
       public Func<string, decimal, decimal, bool> Predicate
       {  
          get 
          { 
              return (s, d1, d2) => OrderNumber.Contains(s) 
                                 && OrderWeight >= d1 
                                 && OrderWeight <= d2; //and so on, u get the idea.
          }  
       }
