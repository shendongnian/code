    List<PropertyInfo> propertyList = new List<PropertyInfo>();
    Type productType = typeof (Product);
    propertyList.Add(productType.GetProperty("Id"));
    propertyList.Add(productType.GetProperty("Title"));
    TargetType target = new TargetType();
    target.Properties = propertyList;
    public class TargetType  {
       public List<PropertyInfo> Properties { get; set;}
       List<object> GetAttributes()
       {
           List<object> attributes = new List<object>();
           foreach(PropertyInfo item in Properties)
           {
               Console.WriteLine(item.Name);
               attributes.AddRange(item.GetCustomAttributes(true));
           }
           return attributes;
       }
    }
