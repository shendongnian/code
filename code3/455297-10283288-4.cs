    public class MyClass 
    {
         public object this[string propertyName] 
         {
            get{
               // probably faster without reflection:
               // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
               // instead of the following
               Type myType = typeof(MyClass);                   
               PropertyInfo myPropInfo = myType.GetProperty(propertyName);
               return myPropInfo.GetValue(this, null);
            }
            set{
               Type myType = typeof(MyClass);                   
               PropertyInfo myPropInfo = myType.GetProperty(propertyName);
               myPropInfo.SetValue(this, value, null);
             
            }
         
         }
    }
