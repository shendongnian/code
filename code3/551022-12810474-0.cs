      internal class ConfigPager : IPager {
         public int PageSize {
             get{
                 int pageSize = 10;  // default value
                 Int32.TryParse(ConfigurationManager.AppSettings["PageSize"], out pageSize);
                 return pageSize;
             }
         }
      }
