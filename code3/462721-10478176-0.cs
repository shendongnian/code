    public static IEnumerable<T> Convert<T>(this IEnumerable<dynamic> self){
        var jsSerializer = new JavaScriptSerializer();
        foreach(var obj in self){
            yield return jsSerializer.ConvertToType<T>(obj);
        }
    }
