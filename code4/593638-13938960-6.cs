    class Helper
    {
        static Dictionary<Type,string> _urls;
        public static string GetUrl(Type ofType)
        {
            return _urls[ofType];
        }
        
        public static void AddUrl(Type ofType, string url)
        {
            _urls.Add(ofType,url);
        }
    }
    class b
    {
        static b(){ Helper.AddUrl(typeof(b),"  ");}
    }
    class Program
    {
        b result= doJSONRequest<b>(Helper.GetUrl(typeof(b));
    }
