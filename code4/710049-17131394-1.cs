    public partial class SearchForm<T> where T : Searchable
    {
       ....
    }
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
                  new ParamInfo(... ,
                  new ParamInfo(...
              }
          }  
       }
