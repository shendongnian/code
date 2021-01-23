        public class ObjectPropertyFormatter :  IPropertyFormatter<Object>
        {
            public string FormatValue(Object value)
            {
                //object fallback formatting logic 
                return  value.ToString();
            }
        }
