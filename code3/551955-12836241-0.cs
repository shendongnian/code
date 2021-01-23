           AddressViewModel avm = new AddressViewModel();
           Type t = avm.GetType();
           object value = null;
           PropertyInfo keyProperty= null;
           foreach (PropertyInfo pi in t.GetProperties())
               {
               object[] attrs = pi.GetCustomAttributes(typeof(KeyAttribute), false);
               if (attrs != null && attrs.Length == 1)
                   {
                   keyProperty = pi;
                   break;
                   }
               }
           if (keyProperty != null)
               {
               value =  keyProperty.GetValue(avm, null);
               }
