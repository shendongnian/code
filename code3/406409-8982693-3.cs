	using System.Collections.Generic;
	public class Test<T>
	{
		public T Value
		{
			 get => _Value; 
			 set
			 {
				// operator== is undefined for generic T; EqualityComparer solves this
				if (!EqualityComparer<T>.Default.Equals(_Value, value))
				{
					_Value = value;
				}
			 }
		}
		private T _Value;
	}
