        object processRecursive(object objSource, Dictionary<object, object> processRefHolder, ITargetObjectResolver targetResolver)
        {
            if (objSource == null) return null;
            //perform filter by type:
            if (typeof(System.Data.IDbConnection).IsAssignableFrom(objSource)) return objSource;            
            //...
                foreach (FieldInfo f in fieldsInfo)
                {
                  if (f.FieldType == typeof(ObjectTransaction)) continue;
                  object objSourceField = f.GetValue(objSource);
                  object objTargetField = Attribute.IsDefined(f,typeof(MyAttributeForSkipTransaction)) //perform filter by field attribute
                                         ? objSourceField 
                                         : processRecursive(objSourceField, processRefHolder, targetResolver);
                  f.SetValue(objTarget, objTargetField);
                }
            //...
        }
