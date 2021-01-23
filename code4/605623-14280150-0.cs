    foreach (var property in oldObject.GetType().GetProperties())
                {
                    var prop= newObject.GetType().GetProperty(property.Name);
                    if (prop!= null)
                        prop.SetValue(newObject, property.GetValue(oldObject));
                }
