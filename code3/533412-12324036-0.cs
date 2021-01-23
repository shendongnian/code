		public static class Initializer
		{
			public static void Initialize()
			{
				foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
					foreach (var type in assembly.GetTypes())
						if (type.IsDefined(typeof(InitializeAttribute), true))
							Console.WriteLine("Need to initialize {0}", type.FullName);
			}
		}
		
		[AttributeUsage(AttributeTargets.Class)]
		public sealed class InitializeAttribute : Attribute
		{ 
		}
		
		[Initialize]
		public sealed class ToBeInitialized
		{ 
		}
