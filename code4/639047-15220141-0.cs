    public class BaseType
    {
      public ArrayOfString GetPropertiesAsArrayOfString(Type type)
      {
        PropertyInfo[] propertyInfos = type.GetProperties();
        List<string> items = new List<string>();
        string propertyType = string.empty;
        
        for (int x = 0; x < propertyInfos.count(); x++)
        {
          switch propertyInfos[x].PropertyType.ToString())
          {
            case "System.String":
                 propertyType = "String";
                 break;
            case "System.DataTime":
                 propertyType = "DateTime";
                 break;
            case "System.Int32":
                 propertyType = "Int32";
                 break;
          }
        
          items.Add(propertyInfos[x].Name + "|" + propertyType);
        }
           
        ArrayOfString properties = new ArrayOfString();
        properties.AddRange(items);
        return properties
      }
    }  
