    public class JsonResult<T> where T : JObject, new()
    {
        public JsonResult(Newtonsoft.Json.Linq.JObject ret, Func<T, object> factory)
        { 
            var tempresult = ret["result"];
            T someResult = factory(tempresult);
        }
    }
