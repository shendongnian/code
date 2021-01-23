    MyClass s = new MyClass();           
    PropertyInfo[] p = s.GetType().GetProperties();
    int i=0;
    foreach (PropertyInfo prop in p)
    {
        prop.SetValue(s, mylist[i++], null); 
    }
