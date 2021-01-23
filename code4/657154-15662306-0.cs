    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(lst[0]))
    {
       Console.WriteLine(descriptor.Name);
    
       if(descriptor.PropertyType == typeof(Car))
       {
          foreach(var child in descriptor.GetChildProperties())
          {
              Console.WriteLine(child.Name);
          }
       }   
    
    }
