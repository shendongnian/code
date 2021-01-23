    var data = (IEnumerable<object>)ddlTest.DataSource;        
    Type t = typeof(MyClass);
    var item = data.ToArray()[0];
    System.Reflection.PropertyInfo pi = t.GetProperty("b");
    int val = (int)pi.GetValue(item, null);
