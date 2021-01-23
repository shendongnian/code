    public class ExpressionEx
	{
		public static Expression Assign(Expression left, Expression right)
		{
			var method = typeof(ExpressionEx).GetMethod("Assign", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(left.Type);
			return Expression.Call(method, left, right);
		}
		private static void Assign<T>(ref T left, T right)
		{
			left = right;
		}
	}
