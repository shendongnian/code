    class UrlAttribute:Attribute
    {
        public string Url{get;private set;}
        public UrlAttribute(string url){Url=url;}
    }
    [Url("someurl")]
    class b { }
    class Program
    {
        UrlAttribute attr = (UrlAttribute)Attribute.GetCustomAttribute(typeof(b), typeof(UrlAttribute));
        //in dot net 4.5 you can ask the type itself
        UrlAttribute attr = (UrlAttribute)typeof(b).GetCustomAttribute(typeof(UrlAttribute));
        b result = doJSONRequest<b>(attr.Url);
    }
