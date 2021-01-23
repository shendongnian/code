    	public object Execute(Expression expression, bool IsEnumerable)
		{
			// Find the call to Where() and get the lambda expression predicate.
			InnermostWhereFinder whereFinder = new InnermostWhereFinder();
			MethodCallExpression whereExpression = whereFinder.GetInnermostWhere(expression);
			LambdaExpression lambdaExpression = (LambdaExpression)((UnaryExpression)(whereExpression.Arguments[1])).Operand;
			// Send the lambda expression through the partial evaluator.
			lambdaExpression = (LambdaExpression)Evaluator.PartialEval(lambdaExpression);
			// Assemble the strings necessary to build this.
			var strings = new List<string>();
			GetStrings(lambdaExpression.Body, strings);
			var query = String.Join(" ", strings);
			return ExecuteQuery(query);
		}
		public abstract object ExecuteQuery(string whereClause);
		public abstract Dictionary<ExpressionType, string> ExpressionTypeToStringMap { get; }
		public abstract string FormatFieldName(string fieldName);
		public abstract string FormatConstant(string constant);
		void GetStrings(System.Linq.Expressions.Expression expression, List<string> toReturn)
		{
			if (expression is BinaryExpression)
			{
				// Binary expression.  Recurse and add to the list.
				GetStrings((BinaryExpression)(expression), toReturn);
			}
			else if (expression is MemberExpression)
			{
				var e = (MemberExpression)(expression);
				toReturn.Add(FormatFieldName(e.Member.Name));
			}
			else if (expression is ConstantExpression)
			{
				var e = (ConstantExpression)(expression);
				toReturn.Add(FormatConstant((string)(e.Value)));
			}
			else
			{
				throw new NotImplementedException("Unaware of how to handle type " + expression.GetType().ToString());
			}
		}
		string NodeTypeToString(ExpressionType type)
		{
			var map = ExpressionTypeToStringMap;
			if(map.ContainsKey(type))
			{
				return map[type];
			}
			
			throw new NotImplementedException("Type '" + type.ToString() + "' not implemented in ExpressionTypeToStringMap.");
		}
		void GetStrings(BinaryExpression expression, List<string> toReturn)
		{
			toReturn.Add("(");
			if (expression.Left != null)
				GetStrings(expression.Left, toReturn);
			toReturn.Add(NodeTypeToString(expression.NodeType));
			if (expression.Right != null)
				GetStrings(expression.Right, toReturn);
			toReturn.Add(")");
		}
