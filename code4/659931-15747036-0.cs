    Type type = typeof(MsClass);
    Type baseType = type.BaseType;
    var baseProperties = 
         type.GetProperties()
              .Where(input => baseType.GetProperties()
                                       .Any(i => i.Name == input.Name)).ToList();
