    public T Delete<T>(T obj) where T : class
            {
                T existing = context.Set<T>().Find(GetKeys(obj, context));
    
                if (existing != null)
                {
                    context.Set<T>().Remove(existing);
                    context.SaveChanges();
                    return existing;
                }
                return null;
            }
    private object[] GetKeys<T>(T entity, DbContext context) where T : class
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<T> set = objectContext.CreateObjectSet<T>();
                var keyNames = set.EntitySet.ElementType
                                                            .KeyMembers
                                                            .Select(k => k.Name).ToArray();
                Type type = typeof(T);
    
                object[] keys = new object[keyNames.Length];
                for (int i = 0; i < keyNames.Length; i++)
                {
                    keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);
                }
                return keys;
            }
