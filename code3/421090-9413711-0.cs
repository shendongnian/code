		public static void Add<T>(this XmlAttributeOverrides overrides, Expression<Func<T, dynamic>> propertySelector, XmlAttributes attributes)
		{
			overrides.Add(typeof(T), propertySelector.BuildString(), attributes);
		}
        public static string BuildString(this Expression propertySelector)
        {
            switch (propertySelector.NodeType)
            {
                case ExpressionType.Lambda:
                    LambdaExpression lambdaExpression = (LambdaExpression)propertySelector;
                    return BuildString(lambdaExpression.Body);
				case ExpressionType.Convert:
				case ExpressionType.Quote:
                    UnaryExpression unaryExpression = (UnaryExpression)propertySelector;
                    return BuildString(unaryExpression.Operand);
                case ExpressionType.MemberAccess:
                    MemberExpression memberExpression = (MemberExpression)propertySelector;
                    MemberInfo propertyInfo = memberExpression.Member;
                    if (memberExpression.Expression is ParameterExpression)
                    {
                        return propertyInfo.Name;
                    }
                    else
                    {
                        // we've got a nested property (e.g. MyType.SomeProperty.SomeNestedProperty)
                        return BuildString(memberExpression.Expression) + "." + propertyInfo.Name;
                    }
                default:
                    // drop out and throw
                    break;
            }
            throw new InvalidOperationException("Expression must be a member expression: " + propertySelector.ToString());
        }
