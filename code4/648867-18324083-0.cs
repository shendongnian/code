        //TEntity is any class derived from TableEnitity 
        public IEnumerable<TEntity> TestingGetPartitionEntities(string PartitionKey)
        {
            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>().Where(
                  TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, PartitionKey));
                EntityResolver<TEntity> resolver = (pk, rk, ts, props, etag) => 
                {
                    //MUST create the 'reflected' instance in the 'EntityResolver', so resolver can create new instance foreach entity in query execution loop.
                    TEntity objectToReturn = (TEntity)Activator.CreateInstance(typeof(TEntity));
                    var objectProperties = objectToReturn.GetType().GetProperties();
                
                    foreach (var prop in props)
                    {
                        PropertyInfo match = objectProperties.FirstOrDefault(v => v.Name == prop.Key);
                        if (match != null)
                        {
                        if (match.PropertyType == typeof(Int32))
                        {
                            match.SetValue(objectToReturn, props[match.Name].Int32Value);
                        }
                        if (match.PropertyType == typeof(object))
                        {
                            match.SetValue(objectToReturn, props[match.Name].PropertyAsObject);
                        }
                        if (match.PropertyType == typeof(bool))
                        {
                            match.SetValue(objectToReturn, props[match.Name].BooleanValue);
                        }
                        if (match.PropertyType == typeof(byte[]))
                        {
                            match.SetValue(objectToReturn, props[match.Name].BinaryValue);
                        }
                        if (match.PropertyType == typeof(DateTimeOffset))
                        {
                            match.SetValue(objectToReturn, props[match.Name].DateTimeOffsetValue);
                        }
                        if (match.PropertyType == typeof(double))
                        {
                            match.SetValue(objectToReturn, props[match.Name].DoubleValue);
                        }
                        if (match.PropertyType == typeof(Guid))
                        {
                            match.SetValue(objectToReturn, props[match.Name].GuidValue);
                        }
                        if (match.PropertyType == typeof(int))
                        {
                            match.SetValue(objectToReturn, props[match.Name].Int32Value);
                        }
                        if (match.PropertyType == typeof(long))
                        {
                            match.SetValue(objectToReturn, props[match.Name].Int64Value);
                        }
                        if (match.PropertyType == typeof(string))
                        {
                            match.SetValue(objectToReturn, props[match.Name].StringValue);
                        }
                    }
                }
                return objectToReturn as TEntity;
            };
            
            //This is the list that is returned to caller.
            List<TEntity> results = new List<TEntity>();
            foreach (TEntity entity in table.ExecuteQuery(query, resolver, null, null))
            {
                results.Add(entity as TEntity);
            }
            return results;
        }
