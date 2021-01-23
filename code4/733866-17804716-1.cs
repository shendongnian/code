    public class BaseViewModel
    {
       public DateTime ReportDate{
         get{
             return ClassHelper.StaticDate;
            }
         set{
             ClassHelper.StaticDate = value;
             RaisePropertyChaged("ReportDate")
            }
       }
    }
    public static ClassHelper : IPropertyChaged
    {
         public object Sync = new object();
         private static DateTime staticDate;
         public static DateTime StaticDate{
           get{
              return staticDate;
           }
           set{
              lock(Sync)
              {
                staticDate = value;                
              }
              RaisePropertyChaged("StaticDate")
           }
         }
    }
