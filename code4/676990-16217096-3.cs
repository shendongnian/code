    public void Set(object obj, string prop, object value)
          {
              //var propInf = obj.GetType().GetProperty(prop);
              //value = Convert.ChangeType(value, propInf.PropertyType);
              //propInf.SetValue(obj, value, null);
              var property = obj.GetType().GetProperty(prop);
              if (property != null)
              {
                  Type t = Nullable.GetUnderlyingType(property.PropertyType)
                               ?? property.PropertyType;
                  object safeValue = (value == null) ? null
                                                     : Convert.ChangeType(value, t);
                  property.SetValue(obj, safeValue, null);
              }
          }
