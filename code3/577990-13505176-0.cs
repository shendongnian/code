    public class Order
    {
        public string OrderNum { private set; get; }
        public string ShortDesc { private set; get; }
        public string Desc { private set; get; }
        public static Order FromJson(string jsonResult) 
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = ((Dictionary<string, object>)js.Deserialize<dynamic>(jsonResult)).First();
            var detail = (Dictionary<string, object>)result.Value;
            
            return new Order()
            {
                OrderNum = result.Key,
                ShortDesc = detail["short_description"].ToString(),
                Desc = detail["detail_description"].ToString()
            };
        }
    }
