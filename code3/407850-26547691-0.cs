    namespace System.Linq {
	
	/// <summary>
	/// author: Filip Sielimowicz inspired by
	/// http://www.entityframework.info/Home/SmallIntProblem
	/// </summary>
	public static class IntCastFixExtension {
		public static IQueryable<T> FixIntCast<T>(this IQueryable<T> q, bool narrowMemberExpr = true, bool narrowConstantExpr = true) {
			var visitor = new FixIntCastVisitor() {
				narrowConstExpr = narrowConstantExpr,
				narrowMembExpr = narrowMemberExpr
			};
			Expression original = q.Expression;
			var expr = visitor.Visit(original);
			return q.Provider.CreateQuery<T>(expr);
		}
		private class FixIntCastVisitor : ExpressionVisitor {
			public bool narrowConstExpr;
			public bool narrowMembExpr;
			protected override Expression VisitBinary(BinaryExpression node) {
				bool eq = node.NodeType == ExpressionType.Equal;
				bool neq = node.NodeType == ExpressionType.NotEqual;
				if (eq || neq) {
					var leftUncasted = ReducePossiblyNotNecessaryIntCastExpr(node.Left);
					var rightUncasted = ReducePossiblyNotNecessaryIntCastExpr(node.Right);
					var rightConst = node.Right as ConstantExpression;
					if (leftUncasted == null) {
						return base.VisitBinary(node);
					}
					if (rightUncasted != null) {
						if (NarrowTypesAreCompatible(leftUncasted.Type, rightUncasted.Type)) {
							// Usuwamy niepotrzebne casty do intów występujące po obu stronach equalsa
							return eq ? Expression.Equal(leftUncasted, rightUncasted) : Expression.NotEqual(leftUncasted, rightUncasted);
						}
					} else if (rightConst != null) {
						// Zamiast casta argumentu z lewej w górę do inta (tak zrobił linq2entity)
						// zawężamy występującą po prawej stałą typu 'int' do typu argumentu z lewej
						if (narrowConstExpr && (rightConst.Type == typeof(int) || rightConst.Type == typeof(int?))) {
							var value = rightConst.Value;
							var narrowedValue = value == null ? null : Convert.ChangeType(rightConst.Value, leftUncasted.Type);
							Expression narrowedConstExpr = Expression.Constant(narrowedValue, leftUncasted.Type);
							return eq ? Expression.Equal(leftUncasted, narrowedConstExpr) : Expression.NotEqual(leftUncasted, narrowedConstExpr);
						}
					} else if (node.Right.NodeType == ExpressionType.MemberAccess) {
						// Jak po prawej mamy wyrażenie odwołujące się do zmiennej typu int to robimy podobnie jak przy stałej
						// - zawężamy to, zamiast upcasta do inta z lewej.
						if (narrowMembExpr) {
							var rightMember = node.Right;
							var narrowedMemberExpr = Expression.Convert(rightMember, leftUncasted.Type);
							return eq ? Expression.Equal(leftUncasted, narrowedMemberExpr) : Expression.NotEqual(leftUncasted, narrowedMemberExpr);
						}
					}
				}
				return base.VisitBinary(node);
			}
			private bool NarrowTypesAreCompatible(Type t1, Type t2) {
				if (t1 == typeof(short?)) t1 = typeof(short);
				if (t2 == typeof(short?)) t2 = typeof(short);
				if (t1 == typeof(byte?)) t1 = typeof(byte);
				if (t2 == typeof(byte?)) t2 = typeof(byte);
				return t1 == t2;
			}
			private bool IsNullable(Type t) {
				return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
			}
			private Expression CorrectNullabilityToNewExpression(Expression originalExpr, Expression newExpr) {
				if (IsNullable(originalExpr.Type) == IsNullable(newExpr.Type)) {
					return newExpr;
				} else {
					if (IsNullable(originalExpr.Type)) {
						Type nullableUncastedType = typeof(Nullable<>).MakeGenericType(newExpr.Type);
						return Expression.Convert(newExpr, nullableUncastedType);
					} else {
						Type notNullableUncastedType = Nullable.GetUnderlyingType(newExpr.Type);
						return Expression.Convert(newExpr, notNullableUncastedType);
					}
				}
			}
			private Expression ReducePossiblyNotNecessaryIntCastExpr(Expression expr) {
				var unnecessaryCast = expr as UnaryExpression;
				if (unnecessaryCast == null ||
					unnecessaryCast.NodeType != ExpressionType.Convert ||
					!(unnecessaryCast.Type == typeof(int) || unnecessaryCast.Type == typeof(int?))
				) {
					// To nie jest cast na inta, do widzenia
					return null;
				}
				if (
					(unnecessaryCast.Operand.Type == typeof(short) || unnecessaryCast.Operand.Type == typeof(byte)
					|| unnecessaryCast.Operand.Type == typeof(short?) || unnecessaryCast.Operand.Type == typeof(byte?))
				) {
					// Jest cast z shorta na inta
					return CorrectNullabilityToNewExpression(unnecessaryCast, unnecessaryCast.Operand);
				} else {
					var innerUnnecessaryCast = unnecessaryCast.Operand as UnaryExpression;
					if (innerUnnecessaryCast == null ||
						innerUnnecessaryCast.NodeType != ExpressionType.Convert ||
						!(innerUnnecessaryCast.Type == typeof(int) || innerUnnecessaryCast.Type == typeof(int?))
					) {
						// To nie jest podwójny cast między intami (np. int na int?), do widzenia
						return null;
					}
					if (
						(innerUnnecessaryCast.Operand.Type == typeof(short) || innerUnnecessaryCast.Operand.Type == typeof(byte)
						|| innerUnnecessaryCast.Operand.Type == typeof(short?) || innerUnnecessaryCast.Operand.Type == typeof(byte?))
					) {
						// Mamy podwójny cast, gdzie w samym środku siedzi short
						// Robimy skrócenie, żeby intów nie produkował zamiast short -> int -> int?
						// powinno ostatecznie wychodzić short -> short czyli brak castowania w ogóle.
						return CorrectNullabilityToNewExpression(unnecessaryCast, innerUnnecessaryCast.Operand);
					}
				}
				return null;
			}
		}
	}
}
