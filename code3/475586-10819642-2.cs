      //custom property class
      public class MyProperty
      {
          public bool IsVisible { get; set; }
          public string PropertyName { get; set; }
      }
      public class Dymo: DynamicObject
      {
          
          Dictionary<MyProperty, object> dictionary
              = new Dictionary<MyProperty, object>();
        
          public override bool TryGetMember(
              GetMemberBinder binder, out object result)
          {
              result = false;
              var prop = PropertyFromName(binder.Name);
              if (prop != null && prop.IsVisible)
                  return dictionary.TryGetValue(prop, out result);
    
              return false;
    
          }
    
          public override bool TrySetMember(
              SetMemberBinder binder, object value)
          {
    
              var prop = PropertyFromName(binder.Name);
              if (prop != null && prop.IsVisible)
                  dictionary[prop] = value;
              else
                  dictionary[new MyProperty { IsVisible = true, PropertyName = binder.Name}] = value;
              return true;
          }
    
          private MyProperty PropertyFromName(string name)
          {
              return (from key in dictionary.Keys where key.PropertyName.Equals(name) select key).SingleOrDefault<MyProperty>();
          }
    
    
          public void SetPropertyVisibility(string propertyName, bool visibility)
          {
              var prop = PropertyFromName(propertyName);
              if (prop != null)
                  prop.IsVisible = visibility;         
          }
      }
