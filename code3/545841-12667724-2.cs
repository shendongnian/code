    IEnumerable<PropertyInfo> MyProperties(object o)
    {
       o.GetProperties.GetType().GetProperties()
        .Where(p => !(p.DeclaringType is Base))
        .Where(p => 
           { 
              var attributes = p.GetCustomAttributes(false);
              return attributes.Any(a => a is DataMemberAttribute)
                 && !attributes.Any(a => a is IgnoreForAllAttribute);
           }
    }
