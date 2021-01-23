    public class DataCacheHelper
    {
        public DataCacheHelper()
        {
            DataCacheFactory factory = new DataCacheFactory();
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["dcf"] = factory;
            HttpContext.Current.Application.Unock();
        }
        public DataCacheFactory GetFactory()
        {
            var factory = HttpContext.Current.Application["dcf"];
            if (factory == null)
            {
                factory = new DataCacheFactory();
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application["dcf"] = factory;
                HttpContext.Current.Application.Unock();
            }
            return factory;
        }
    }
