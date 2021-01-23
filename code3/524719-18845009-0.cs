public class CacheManager
    {
        #region ICacheManager Members
        public static void Add(string key, object value, int expireSeconds)
        {
            if (expireSeconds == CacheManagerKey.CacheLifeSpanForever)
                WebCache.Add(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            else
                WebCache.Add(key, value, null, DateTime.MaxValue, TimeSpan.FromSeconds(expireSeconds), CacheItemPriority.Normal, null);
        }
        public static bool Contains(string key)
        {
            return WebCache.Get(key) != null;
        }
        public static int Count()
        {
            return WebCache.Count;
        }
        public static void Insert(string key, object value)
        {
            WebCache.Insert(key, value);
        }
        public static T Get<T>(string key)
        {
            return (T)WebCache.Get(key);
        }
        public static List<string> GetCacheKeys()
        {
            List<string> keys = new List<string>();
            foreach (DictionaryEntry entry in HttpContext.Current.Cache) keys.Add(entry.Key.ToString());
            return keys;
        }
        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
        public static void RemoveAll()
        {
            List<string> keys = GetCacheKeys();
            foreach (string key in keys)
                WebCache.Remove(key);
        }
        public object this[string key]
        {
            get
            {
                return WebCache[key];
            }
            set
            {
                WebCache[key] = value;
            }
        }
        #endregion
        public static System.Web.Caching.Cache WebCache
        {
            get
            {
                System.Web.Caching.Cache cache = null;
                if (HttpContext.Current != null)
                    cache = HttpContext.Current.Cache;
                if (cache == null)
                    cache = HttpRuntime.Cache;
                return cache;
            }
        }
    }
    </pre>
 - After that I created my own attribute
        [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
        public class WebCacheAttribute : ActionFilterAttribute
        {
            public int Duration { get; set; }
            public string CacheKey { get; set; }
            public Dictionary<string, dynamic> CacheParams { get; set; }
            public Type CacheReturnType { get; set; }
            public string ContentType { get; set; }
            public HeaderContentTypeEnum ResponseHeaderContentType{get;set;}
            public string CacheObj { get; set; }
            private readonly ICacheHoleFiller _cacheHoleFiller;
    
            public WebCacheAttribute(int duration, string cacheKey, string cacheParamsStr, HeaderContentTypeEnum response = HeaderContentTypeEnum.Html, Type type = null)
            {
    
            }
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
    
            }
    
            public T GetCachedParam<T>(Dictionary<string, object> parameters, bool isAjaxRequest)
            {
    
            }
    
            public string GetUniqueKey(bool isAjaxRequest)
            {
    
            }
    
            public void OnException(ExceptionContext filterContext)
            {
    
            }
    
            private HtmlTextWriter tw;
            private StringWriter sw;
            private StringBuilder sb;
            private HttpWriter output;
    
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
    
            }
    
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
    
            }
    }
    </pre>
 - To have some parts dynamic I used ["Donut Caching"][2]
 - Lastly, I created a cachehelper to call other methods in my project that will use the webcache attribute as well.
var articleStr = CacheHelper.InvokeCacheMethod<string>(typeof(HtmlHelperExtensions), "RenderArticlesCallback", new object[] { (int)articleType });
[WebCacheAttribute(CacheManagerKey.CacheLifeSpanForever, CacheManagerKey.Page_Article_Key, "articleTypeID")]
            public static string RenderArticlesCallback(int articleTypeID)
            {</pre>
public static class CacheHelper
    {
        public delegate object SourceDataDelegate(object[] args);
        public static T InvokeCacheMethod<T>(Type type, string methodName, object[] args)
        {
            return (T)InvokeCacheMethod<T>(type, methodName, null, args);
        }
        public static T InvokeCacheMethod<T>(Type type, string methodName, object instance, object[] args)
        {
            var method = type.GetMethod(methodName);
            var webCache = method.ReturnParameter.Member.GetCustomAttributes(typeof(WebCacheAttribute), true).FirstOrDefault();
            Dictionary<string, object> cacheParameters = FixCacheParameters(method, args);
            T cachedObj;
            if (Config.CacheEnabled && webCache != null)
            {
                cachedObj = ((WebCacheAttribute)webCache).GetCachedParam<T>(cacheParameters, false);
                if (cachedObj != null)
                    return cachedObj;
            }
            T returnObj = (T)method.Invoke(instance, args);
            SaveCachedData<T>(webCache, returnObj);
            return returnObj;
        }
        public static void SaveCachedData<T>(object webCache, object returnObj)
        {
            if (Config.CacheEnabled && webCache != null)
            {
                var fullParamString = ((WebCacheAttribute)webCache).GetUniqueKey(false);
                CacheManager.Add(fullParamString, returnObj, ((WebCacheAttribute)webCache).Duration);
            }
        }
        public static Dictionary<string, object> FixCacheParameters(MethodInfo method, object[] args)
        {
            Dictionary<string, object> cacheParameters = new Dictionary<string, object>();
            if (args != null)
            {
                var arguments = args.ToList();
                var count = 0;
                var argsCount = args.Length;
                var methodParameters = method.GetParameters().ToList();
                foreach (var argument in args)
                {
                    var key = methodParameters[count].Name;
                    object value = null;
                    if (argsCount > count)
                        value = args[count];
                    if (value != null && value.GetType() == typeof(string))
                        value = (object)value.ToString();
                    if (value != null)
                        cacheParameters.Add(key, value);
                    count++;
                }
            }
            return cacheParameters;
        }
    }</pre>
For more details on all of this you can visit my blog post => [Custom Output Caching in ASP.NET MVC][1]
  [1]: http://bstavroulakis.com/blog/web/custom-output-caching-in-asp-net-mvc/
  [2]: http://mvcdonutcaching.codeplex.com/
