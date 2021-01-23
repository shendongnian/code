	public interface InterfaceBase { }
	public interface Interface1 : InterfaceBase { }
	public interface InterfaceX : InterfaceBase { }
	public class Concrete1 : Interface1 { }
	public class ConcreteX : InterfaceX { }
	public static class Factory
	{
		public static T Get<T>()
			where T : InterfaceBase
		{
			if (typeof(Interface1).IsAssignableFrom(typeof(T)))
			{
				return (T)(InterfaceBase)new Concrete1();
			}
			// ...
			else if (typeof(InterfaceX).IsAssignableFrom(typeof(T)))
			{
				return (T)(InterfaceBase)new ConcreteX();
			}
			throw new ArgumentException("Invalid type " + typeof(T).Name, "T"); // Avoids "not all code paths return a value".
		}
	}
