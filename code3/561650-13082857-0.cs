      public void setSpeed()
      {
           Type type = this.GetType(); 
           PropertyInfo property = type.GetProperty(PropertyName );
           property.SetValue(this, Convert.ToInt32(PropertyValue), null);
      }
