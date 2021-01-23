    foreach (PropertyInfo prp in obj.GetType().GetProperties()) {
       if (prp.CanRead) {
          object value = prp.GetValue(obj, null);
          string s = value == null ? "" : value.ToString();
          string name = prp.Name;
          ...
       }
    } 
