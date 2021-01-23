	public class MyObject
	{
		public MyObject(int anyValue)
		{
			...
		}
	}
    Action<MyObject, int> c = typeof(MyObject)
        .GetConstructor(new [] { typeof(int) })
        .CreateDelegate<Action<MyObject, int>>();
    MyObject myObject = new MyObject(1;
    c(myObject, 2);
