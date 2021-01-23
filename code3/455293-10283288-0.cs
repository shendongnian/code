    public class MyClass 
    {
         public object this[string propertyName] 
         {
            get{
               Type myType=typeof(MyClass);                   
               PropertyInfo myPropInfo = myType.GetProperty(propertyName);
               return myPropInfo.Value;
            }
            set{
               Type myType=typeof(MyClass);                   
               PropertyInfo myPropInfo = myType.GetProperty(propertyName);
               myPropInfo .SetValue(this, vakue, null);
             
            }
         
         }
    }
