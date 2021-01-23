      var result = new List<Data>();
      var data = new Data();
      var type = data.GetType();
      var fieldName = "Something";
      for (var i = 0; i < list.Count; i++)
      {
          foreach (var property in data.GetType().GetProperties())
          {
             if (property.Name == fieldName)
             {
                type.GetProperties().FirstOrDefault(n => n.Name == property.Name).SetValue(data, GetPropValue(list[i], property.Name), null);
                result.Add(data);
             }
          }
      }
