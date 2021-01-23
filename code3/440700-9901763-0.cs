    public static class ObjectExtensions
    {
      public static void CopyFrom(this object Instance, object Source)
      {
        ObjectExtensions.CopyFrom(Instance, Source, false, null);
      }
      public static void CopyFrom(this object Instance, 
                                  object Source, 
                                  IEnumerable<string> IgnoreProperties)
      {
        ObjectExtensions.CopyFrom(Instance, Source, false, IgnoreProperties);
      }
      public static void CopyFrom(this object Instance, 
                                  object Source, 
                                  bool ThrowOnPropertyMismatch, 
                                  IEnumerable<string> IgnoreProperties)
      {
        Type sourceType = Source.GetType();
        BindingFlags publicInstanceFlags = BindingFlags.Public 
                                           | BindingFlags.Instance;
        PropertyInfo[] sourceProperties = 
          sourceType.GetProperties(publicInstanceFlags);
        Type instanceType = Instance.GetType();
        foreach (PropertyInfo sourceProperty in sourceProperties)
        {
          if (IgnoreProperties == null
              || (IgnoreProperties.Count() > 0
                  && !IgnoreProperties.Contains(sourceProperty.Name)))
         {
           PropertyInfo instanceProperty = 
             instanceType.GetProperty(sourceProperty.Name, publicInstanceFlags);
           if (instanceProperty != null
               && instanceProperty.PropertyType == sourceProperty.PropertyType
               && instanceProperty.GetSetMethod() != null
               && instanceProperty.GetSetMethod().IsPublic)
           {
             instanceProperty.SetValue(Instance, 
                                       sourceProperty.GetValue(Source, null), 
                                       null);
           }
           else 
           if (ThrowOnPropertyMismatch
               && instanceProperty.PropertyType != sourceProperty.PropertyType)
           {
             throw new InvalidCastException(
               string.Format("Unable to cast source {0}.{1} to destination {2}.{3}.",
                             Source.GetType().Name,
                             sourceProperty.Name,
                             Instance.GetType().Name,
                             instanceProperty.Name));
           }
         }
       }
    }
    
