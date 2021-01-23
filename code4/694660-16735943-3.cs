    static class AssertResemblance
	{
		public static void Like<T, T2>( IEnumerable<T> expected, IEnumerable<T2> actual )
		{
			Like<T, T2>( expected, actual, x=>x );
		}
		public static void Like<T, T2>( IEnumerable<T> expected, IEnumerable<T2> actual, Func<Likeness<T, T2>, Likeness<T, T2>> configureLikeness )
		{
			Assert2.Collection( actual, SelectShouldEqualAsAction( expected.Select( x => configureLikeness( x.AsSource().OfLikeness<T2>() ) ) ) );
		}
		public static void Like<T>( IEnumerable<T> expected, IEnumerable<T> actual, Func<IEnumerable<T>, IEnumerable<T>> unify )
		{
			Like<T>( expected, actual, unify, x=>x );
		}
        public static void Like<T>( IEnumerable<T> expected, IEnumerable<T> actual, Func<IEnumerable<T>,IEnumerable<T>> unify, Func<Likeness<T, T>, Likeness<T, T>> configureLikeness )
		{
			Assert2.Collection( unify( actual ), SelectShouldEqualAsAction( unify(expected).Select( x => configureLikeness( x.AsSource().OfLikeness<T>() ) ) ) );
		}
		static Action<TDestination>[] SelectShouldEqualAsAction<TSource, TDestination>( IEnumerable<Likeness<TSource, TDestination>> that )
		{
			return (from it in that select (Action<TDestination>)it.ShouldEqual).ToArray();
		}
	}
