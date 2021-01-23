	public static TValue It.Is<TValue>(Expression<Func<TValue, bool>> match)
	{
			return Match<TValue>.Create(
					value => match.Compile().Invoke(value),
					() => It.Is<TValue>(match));
	}
	
	public static T Create<T>(Predicate<T> condition, Expression<Func<T>> renderExpression)
	{
			// ...
			return default(T);
	}
	
