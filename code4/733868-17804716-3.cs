    public class BaseViewModel
    {
        public DateTime ReportDate
        {
            get
            {
                return ClassHelper.StaticDate;
            }
            set
            {
                ClassHelper.StaticDate = value;
                RaisePropertyChanged("ReportDate")
            }
         }
    }
    public static ClassHelper : IPropertyChaged
    {
        private static object sync = new object();
        private static DateTime staticDate;
        public static DateTime StaticDate
        {
            get
            {
                return staticDate;
            }
            set
            {
                lock(sync)
                {
                    staticDate = value;                
                }
                RaisePropertyChanged("StaticDate")
            }
        }
    }
