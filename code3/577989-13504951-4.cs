    public class Order {
         public string OrderNum { private set; get; }
         public string ShortDesc { private set; get; }
         public string Desc { private set; get; }
         public static Order FromJson(object jsonResult) 
         {
              var m = jsonResult as Map<string, object>;
              // Handle errors, but I am not
              var firstPair = m.First();
              var detail = firstPair.Value as Map<string, object>;
              
              var dummy = new Order()
              {
                  OrderNum = firstPair.Key,
                  ShortDesc = detail["short_description"].ToString();
                  Desc = detail["detail_description"].ToString();
              }
              return dummy;
         }
    }
