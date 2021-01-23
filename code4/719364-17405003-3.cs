    public void UpdateSingle<T>(T item) where T : class
    {
        // If entity is Sortable, update the indexes of the records between the new and the old index of the updated entity
        var sortable = item as ISortable;
        if (sortable != null)
        {
            Detach(item);   // need to detach the entity from the context in order to retrieve the old values from DB
            var oldItem = Find<T>(sortable.Id);
    
            if (oldItem != null && sortable.Idx != oldItem.Idx)
            {
                UpdateSingleSortable(oldItem, sortable);
            }
    
            Detach(oldItem);
            Attach(item);   // re-attach to enable saving
        }
    
        Entry(item).State = EntityState.Modified;
    
        Commit();
    }
    
    public void UpdateSingleSortable<T>(T oldItem, ISortable sortable)
        where T : class
    {
        var entities = FindAll<T>();
    
        var oldIdx = oldItem.Idx;
        var newIdx = sortable.Idx;
    
        if (newIdx > oldIdx)
        {
            var expression = GenerateExpressionA(oldItem, newIdx, oldIdx);
            var typedExpression = expression as Expression<Func<T, bool>>;
            var toUpdate = entities.Where(typedExpression).Select(a => a);
            foreach (var toUpdateEntity in toUpdate)
            {
                toUpdateEntity.Idx = toUpdateEntity.Idx - 1;
            }
        }
        else
        {
            var expression = GenerateExpressionB(oldItem, newIdx, oldIdx);
            var typedExpression = expression as Expression<Func<T, bool>>;
            var toUpdate = entities.Where(typedExpression).Select(a => a);
            foreach (var toUpdateEntity in toUpdate)
            {
                toUpdateEntity.Idx = toUpdateEntity.Idx + 1;
            }
        }
    }
    Expression GenerateExpressionB<T>(T t, int? newIdx, int? oldIdx)
    {
        //    a => a.Idx >= newIdx && a.Idx < oldIdx
        var underlyingType = t.GetType();
        var idxGetter = underlyingType.GetProperty("Idx");
    
        Type genericFunc = typeof(Func<,>);
        Type[] typeArgs = { underlyingType, typeof(bool) };
        Type returnType = genericFunc.MakeGenericType(typeArgs);
    
        var param = Expression.Parameter(underlyingType);
        var toReturn = Expression.Lambda(
            returnType,
            Expression.And
            (
                Expression.GreaterThanOrEqual(
                    Expression.MakeMemberAccess(param, idxGetter),
                    Expression.Constant(newIdx, typeof(int?))
                ),
                Expression.LessThan(
                    Expression.MakeMemberAccess(param, idxGetter),
                    Expression.Constant(oldIdx, typeof(int?))
                )
            ),
            param);
        
        return toReturn;
    }
    
    Expression GenerateExpressionA<T>(T t, int? newIdx, int? oldIdx)
    {
        //    a => a.Idx <= newIdx && a.Idx > oldIdx
        var underlyingType = t.GetType();
        var idxGetter = underlyingType.GetProperty("Idx");
    
        Type genericFunc = typeof(Func<,>);
        Type[] typeArgs = { underlyingType, typeof(bool) };
        Type returnType = genericFunc.MakeGenericType(typeArgs);
    
        var param = Expression.Parameter(underlyingType);
        var toReturn = Expression.Lambda(
            returnType,
            Expression.And
            (
                Expression.LessThanOrEqual(
                    Expression.MakeMemberAccess(param, idxGetter),
                    Expression.Constant(newIdx, typeof(int?))
                ),
                Expression.GreaterThan(
                    Expression.MakeMemberAccess(param, idxGetter),
                    Expression.Constant(oldIdx, typeof(int?))
                )
            ),
            param);
        toReturn.Dump();
        
        return toReturn;
    }
