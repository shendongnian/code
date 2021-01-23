    foreach (var propertyName in entity.GetType().GetProperties().Where(p=>!p.PropertyType.IsGenericType).Select(p=>p.Name))
       {
          var value = entity.GetType().GetProperty(propertyName).GetValue(entity, null);
          if (value != null)
          oldEntry.GetType().GetProperty(propertyName).SetValue(oldEntry, value, null);
        }
