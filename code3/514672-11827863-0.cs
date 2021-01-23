    private static void GetDTOProperties(IDictionary<string, object> dicProperties, object objectToSerialize)
    {
       Type typeOfObject = objectToSerialize is Type ? objectToSerialize as Type : objectToSerialize.GetType();
       PropertyInfo[] properties = typeOfObject.GetProperties();
       foreach (PropertyInfo property in properties)
       {
          object val = objectToSerialize is Type ? property.PropertyType : property.GetValue(objectToSerialize, null);
          if (!property.PropertyType.IsClass || property.PropertyType.Equals(typeof(string)))
          {
             dicProperties.Add(string.Format("{0}_{1}", property.DeclaringType.Name.ToLower(), property.Name.ToLower()), val);                    
          }
          else
             GetDTOProperties(dicProperties, val);
       }
    }
