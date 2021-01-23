    types.Push(new TypeHelper 
               {
                   Type = propertyInfo.PropertyType, 
                   Name = propertyInfo.Name + propertyInfo.DeclaringType.Name, 
                   Value= propertyInfo.GetValue(this,null).ToString() 
               }
    );
