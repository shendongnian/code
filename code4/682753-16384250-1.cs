	/// <summary>
	/// Class to allow operations (like add, multiply, etc.) for generic types. This type should allow these operations themselves.
	/// If a type does not support an operation, an exception is throw when using this operation, not during construction of this class.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public static class Calculator<T>
	{
		public delegate T Operation(T a, T b);
		static Calculator()
		{
			Add = CreateDelegate(Expression.AddChecked);
			Subtract = CreateDelegate(Expression.SubtractChecked);
			Multiply = CreateDelegate(Expression.MultiplyChecked);
			Divide = CreateDelegate(Expression.Divide);
		}
		static private T InvalidOperation(T a, T b)
		{
			throw new InvalidOperationException("This operation is not supported by type " + typeof(T).FullName + "!");
		}
		static private Operation CreateDelegate(Func<Expression, Expression, Expression> @operator)
		{
			try
			{
				Type convertToType = null;;
				switch(Type.GetTypeCode(typeof(T)))
				{
					case TypeCode.Byte:
					case TypeCode.SByte:
					case TypeCode.Int16:
					case TypeCode.UInt16:
						convertToType = typeof(int);
						break;
				}
				ParameterExpression parameterA = Expression.Parameter(typeof(T), "a");
				ParameterExpression parameterB = Expression.Parameter(typeof(T), "b");
				Expression valueA = (convertToType != null) ? Expression.Convert(parameterA, convertToType) : (Expression)parameterA;
				Expression valueB = (convertToType != null) ? Expression.Convert(parameterB, convertToType) : (Expression)parameterB;
				Expression body = @operator(valueA, valueB);
				if (convertToType != null)
					body = Expression.ConvertChecked(body, typeof(T));
				return Expression.Lambda<Operation>(body, parameterA, parameterB).Compile();
			}
			catch(Exception e)
			{
				return InvalidOperation;
			}
		}
		/// <summary>
		/// Adds two values of the same type.
		/// </summary>
		public static readonly Operation Add;
		/// <summary>
		/// Subtracts two values of the same type.
		/// </summary>
		public static readonly Operation Subtract;
		/// <summary>
		/// Multiplies two values of the same type.
		/// </summary>
		public static readonly Operation Multiply;
		/// <summary>
		/// Divides two values of the same type.
		/// </summary>
		public static readonly Operation Divide;
	}
