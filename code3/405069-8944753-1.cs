        public class DateTimePropertyFormatter :  IPropertyFormatter<DateTime> 
        {
            public string FormatValue(DateTime value)
            {
                //DateTime customised formatting logic 
                return "<b>" + value.ToString("yyyyMMdd") + "</b>";
            }
        }
        public class BoolPropertyFormatter :  IPropertyFormatter<bool>
        {
            public string FormatValue(bool value)
            {
                //bool customised formatting logic 
                if (value) 
                    return "yeaaah"; 
                else 
                    return "nope";
            }
        }
