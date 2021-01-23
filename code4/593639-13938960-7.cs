    class UrlAttribute:Attribute
    {
        public string Url{get;private set;}
        public UrlAttribute(string url){Url=url;}
    }
    [Url("someurl")]
    class b { }
    class Program
    {
        void Main()
        {
            UrlAttribute attr = (UrlAttribute)Attribute.GetCustomAttribute(typeof(b), typeof(UrlAttribute));
            //in dot net 4.5 you can ask the type itself
            UrlAttribute attr = (UrlAttribute)typeof(b).GetCustomAttribute(typeof(UrlAttribute));
            //now you can write that...
            b result = doJSONRequest<b>(attr.Url);
        }
        //or even you can do that in doJSONRequest itself
        public T doJSONRequest<T>()
        {
             UrlAttribute attr = (UrlAttribute)typeof(T).GetCustomAttribute(typeof(UrlAttribute));
            ...
            //call it: b result=doJSONRequest<b>();
        } 
    }
