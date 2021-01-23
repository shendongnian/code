    private void SetParam(string name, string property, dynamic value)
    {
          // Find the object based on it's name
          object target = this.FindName(name);
          if (target != null)
          {
              // Find the correct property
              Type type = target.GetType();
              PropertyInfo prop = type.GetProperty(property);
  
              // Change the value of the property
              prop.SetValue(target, value);
          }
    }
