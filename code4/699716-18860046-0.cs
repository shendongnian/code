    public static class DataExtensions
    {
        public static TEntity InsertIfNotExists<TEntity>(this ObjectSet<TEntity> objectSet, Expression<Func<TEntity, bool>> predicate) where TEntity : class, new()
        {
            TEntity entity;
            #region Check DB
            entity = objectSet.FirstOrDefault(predicate);
            if (entity != null)
                return entity;
            
            #endregion
            //NOT in the Database... Check Local cotext so we do not enter duplicates
            #region Check Local Context
            entity = objectSet.Local().AsQueryable().FirstOrDefault(predicate);
            if (entity != null)
                return entity;
            #endregion
            ///********* Does NOT exist create entity *********\\\
            entity = new TEntity();
            // Parse Expression Tree and set properties
            //Hit a recurrsive function to get all the properties and values
            var body = (BinaryExpression)((LambdaExpression)predicate).Body;
            var dict = body.GetDictionary();
            //Set Values on the new entity
            foreach (var item in dict)
            {
                entity.GetType().GetProperty(item.Key).SetValue(entity, item.Value);
            }
            return entity;
        }
        public static Dictionary<string, object> GetDictionary(this BinaryExpression exp)
        {
            //Recurssive function that creates a dictionary of the properties and values from the lambda expression
            var result = new Dictionary<string, object>();
            if (exp.NodeType == ExpressionType.AndAlso)
            {
                result.Merge(GetDictionary((BinaryExpression)exp.Left));
                result.Merge(GetDictionary((BinaryExpression)exp.Right));
            }
            else
            {
                result[((MemberExpression)exp.Left).Member.Name] = exp.Right.GetExpressionVaule();
            }
            return result;
        }
        public static object GetExpressionVaule(this Expression exp)
        {
            if (exp.NodeType == ExpressionType.Constant)
                return ((ConstantExpression)exp).Value;
            if (exp.Type.IsValueType)
                exp = Expression.Convert(exp, typeof(object));
            //Taken From http://stackoverflow.com/questions/238413/lambda-expression-tree-parsing
            var accessorExpression = Expression.Lambda<Func<object>>(exp);
            Func<object> accessor = accessorExpression.Compile();
            return accessor();
        }
        public static IEnumerable<T> Local<T>(this ObjectSet<T> objectSet) where T : class
        {
            //Taken From http://blogs.msdn.com/b/dsimmons/archive/2009/02/21/local-queries.aspx?Redirected=true
            return from stateEntry in objectSet.Context.ObjectStateManager.GetObjectStateEntries(
                       EntityState.Added | 
                       EntityState.Modified | 
                       EntityState.Unchanged)
                   where stateEntry.Entity != null && stateEntry.EntitySet == objectSet.EntitySet
                   select stateEntry.Entity as T;
        }
        public static void Merge<TKey, TValue>(this Dictionary<TKey, TValue> me, Dictionary<TKey, TValue> merge)
        {
            //Taken From http://stackoverflow.com/questions/4015204/c-sharp-merging-2-dictionaries
            foreach (var item in merge)
            {
                me[item.Key] = item.Value;
            }
        }
    }
