    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValue : Attribute
    {
     public string ElementName {get; set;}
     public string AttributeName {get; set;}
     public object DefaultValue {get; set;}
     
    public object GetValue(XElement element)
    {
      var v = root.Attribute(AttributeName);
     if(v!= null)
      return v.value;
     else
      return DefaultValue
    }
    }
