    public static void SetData<T>(T obj)
    {
      foreach (var property in typeof(T).GetProperties())
        if (property.CanWrite && property.GetIndexParameters().Length == 0)
        {
          object val = null;
          //// Optionally some custom logic if you like:
          //if (property.PropertyType == typeof(string))
          //    val = "Jan-Peter Vos";
          //else
            val = Activator.CreateInstance(property.PropertyType);
          property.SetValue(obj, val, null);
        }
    }
    [Test]
    public void FirstSteps()
    {
      // .. Your code ..
      
      SetData(view);
    }
