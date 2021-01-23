	public class Singleton<T> where T : class
	{
	
		protected Singleton()
		{
		}
	
		public static T Instance
		{
			get { return SingletonFactory.instance; }
		}
	
		public void SetInfo(string url, string username, string password)
		{
			...
		}
		
		public string GetVersion()
		{
			...
		}
	
		class SingletonFactory
		{
	
			internal static readonly T instance;
	
			static SingletonFactory()
			{
				ConstructorInfo constructor = typeof(T).GetConstructor(
						   BindingFlags.Instance | BindingFlags.NonPublic,
						   null, new System.Type[0],
						   new ParameterModifier[0]);
	
				if (constructor == null)
					throw new Exception(
						"Target type is missing private or protected no-args constructor: type=" + 
						typeof(T).FullName);
				try
				{
					instance = constructor.Invoke(new object[0]) as T;
				}
				catch (Exception e)
				{
					throw new Exception(
						"Failed to create target: type=" + typeof(T).FullName, e);
				}
			}
	
		}
	
	}
	
	public class Advanced : Singleton<Advanced>
	{
		...
	}
