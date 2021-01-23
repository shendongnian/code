    class Parent
    {
      ...
    }
    
    class Child :Parent
    {
      ...
      public Child(Parent p)
      {
                foreach (FieldInfo prop in  p.GetType().GetFields())
                    GetType().GetField(prop.Name).SetValue(this, prop.GetValue( p));
    
                foreach (PropertyInfo prop in  p.GetType().GetProperties())
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue( p, null), null);
      }
    }
