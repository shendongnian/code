     var identityAttribute = (IdentityAttribute)Attribute.GetCustomAttribute(...);
     // If you can call GetCustomAttribute successfully then you can also easily
     // find which class defines the decorated property
     var baseClass = ... ;
     // And pass this information to GenerateValue
     var value = identityAttribute.GenerateValue(baseClass);
