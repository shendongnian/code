    foreach (var p in type.GetProperties())
    {
             if (p.GetCustomAttributes(typeof(ChangeRequestFieldAttribute), false).Count() > 0)
             {
                   //just get the value of the property & cast it.
                   var propertyValue = p.GetValue(<the instance>, null);
                   if (propertyValue !=null && propertyValue is ContactStringProperty)
                   {
                       var contactString = (ContactStringProperty)property;
                       contactString.SameValueAs(...);
                   }
             }
      }
