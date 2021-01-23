     if (!Object.Equals(
         item.GetValue(person, null),
         dto.GetType().GetProperty(item.Name).GetValue(dto, null)))
     { 
       diffProperties.Add(item);
     } 
