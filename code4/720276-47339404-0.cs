		public abstract class BaseClass
		{
		}
		public abstract class CopyableClass<T> : BaseClass
			where T: BaseClass, new()
		{
			public T Copy()
			{
				var copy = new T(); // Creating a new instance as proof of concept
				return copy;
			}
		}
		public class DerivedClass : CopyableClass<DerivedClass>
		{
		}
