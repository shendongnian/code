    MyClass myObj = new MyClass();
    ...
    foreach (var pi in typeof(MyClass).GetProperties())
    {
         object value;
         if (myDictionary.TryGetValue(pi.Name, out value)
         {
              pi.SetValue(myObj, value);
         }
    }
