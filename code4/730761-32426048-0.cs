    	public static class GenericHelper<TEntity> {
		    public static string GetPropertyName<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression) {
			    return propertyExpression.GetPropertyName();
		    }
	    }
