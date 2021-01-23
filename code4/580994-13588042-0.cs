        protected Expression<Func<DbEntity, LocalEntity>> getSelectExpression()
        {
        	ParameterExpression paramExpr = Expression.Parameter(typeof(DbEntity), "dbRecord");
        	var selectLambda = Expression.Lambda<Func<DbEntity, LocalEntity>>(
        						Expression.MemberInit(
        							Expression.New(typeof(LocalEntity)),
        							Expression.Bind(typeof(LocalEntity).GetProperty("DbEntityFieldName"), Expression.Property(paramExpr, "DbEntityFieldName"),
        							....
        							))
        						),
        						paramExpr);
        
        	return selectLambda;
        }
