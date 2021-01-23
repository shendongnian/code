    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace zielonka.co.uk.extensions.system
    {
        //DateTime lastDay = DateTime.Now.GetLastDateTimeOfMonth();
    
        public static partial class DateTimeExtensions
        {
            public static DateTime GetLastDateTimeOfMonth(this DateTime dateTime)
            {
                return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
            }
        }
    }
