    public delegate object ParameterConverter(string val);
    
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterConverterAttribute : ParameterBaseAttribute
    {
        public ParameterConverter Converter { get; set; }
        public ParameterConverterAttribute(Type delegateType, string method)
        {
         try{ // Important as GetMethod can throw error exception or return null
            this.Converter = (ParameterConverter)Delegate.CreateDelegate(delegateType, delegateType.GetMethod(method));
          }
          catch { } 
        }
        public object Convert(string val)
        {
            if(this.Converter != null)
                 return Converter(val);
        }
    }
