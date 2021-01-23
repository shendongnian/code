    public class OnePropertySpecifiedAttribute : ValidationAttribute
    {       
        public override bool IsValid(object value)
        {            
             Type typeInfo = value.GetType();
             PropertyInfo[] propertyInfo = typeInfo.GetProperties();
             foreach (var property in propertyInfo)
             {
                if (null != property.GetValue(value, null))
                {                    
                   return true;
                }
             }           
             return false;
        }
    }
