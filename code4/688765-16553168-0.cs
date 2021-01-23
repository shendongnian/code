    PropertyInfo[] properties = typeof(basetype).GetProperties();
    basetype b = new basetype();
    foreach (PropertyInfo pi in properties)
    {
         if (pi.GetSetMethod() != null)
         {
            pi.SetValue(b, pi.GetValue(theobject,null), null);
         }
    }
