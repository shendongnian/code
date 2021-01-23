      foreach(T item in list)
      {
          var props = item.GetType().GetProperties();
          foreach(var prop in props)
          {   
              var propName = prop.Name;
              var value = prop.GetValue(item));
          }
      }
