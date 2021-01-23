    public class JsonResult<T> where T : JObject, new()
    {
        public JsonResult(Newtonsoft.Json.Linq.JObject ret, Func<object, T> factory)
        { 
            var tempresult = ret["result"];
            T someResult = factory(tempresult);
        }
    }
