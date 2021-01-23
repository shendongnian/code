	public class Maybe<T>
	{
		public static readonly Maybe<T> Nothing = new Maybe<T>();
		private Maybe()	{}
		public T Value { get; private set;}
		public Maybe(T value) { Value = value; }
	}
	public static class MaybeExt
	{
		public static bool IsNothing<T>(this Maybe<T> me)
		{
			return me == Maybe<T>.Nothing;
		}
		public static Maybe<T> May<T>(this T value)
		{
			return ReferenceEquals(value, null) ? Maybe<T>.Nothing : new Maybe<T>(value);
		}
		// Note: this is basically just "Bind"
		public static Maybe<U> SelectMany<T,U>(this Maybe<T> me, Func<T, Maybe<U>> map)
		{
			return me != Maybe<T>.Nothing ?
				// extract, map, and rebox
				map(me.Value) :
				// We have nothing, so we pass along nothing...
				Maybe<U>.Nothing;
		}
		// This overload is the one that "turns on" query comprehension syntax...
		public static Maybe<V> SelectMany<T,U,V>(this Maybe<T> me, Func<T, Maybe<U>> map, Func<T,U,V> selector)
		{
			return me.SelectMany(x => map(x).SelectMany(y => selector(x,y).May()));
		}
	}
