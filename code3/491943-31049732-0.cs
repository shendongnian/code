    public class MyGenericClass<TSomeClass>
    {
    }
	public static class MyGenericClassExtensions
	{
		public static void MyGenericMethod<TSomeClass, TSomeInterface>(this MyGenericClass<TSomeClass> self)
			where TSomeClass : TSomeInterface
		{
			//...
		}
	}
