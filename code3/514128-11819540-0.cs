	//public fields are of this type
	public class TestClass
	{
	}
	//Class with public fields
	public class TestContainerClass
	{
		public TestClass TestClassField1;
		public TestClass TestClassField2;
		public TestClass TestClassField3;
		public TestClass TestClassField4;
		//should fill this list on creation of first instance and then use it
		//assume that type is not changed in a runtime
		private static List<Action<TestContainerClass,TestClass>> _fieldInitializers;
		public TestContainerClass()
		{
			if (_fieldInitializers == null)
			{
				_fieldInitializers = new List<Action<TestContainerClass, TestClass>>();
				//use reflection only once
				FieldInfo[] testClassFieldInfos =
					this.GetType().GetFields().Where(f => f.FieldType == typeof (TestClass)).ToArray();
				foreach (var testClassFieldInfo in testClassFieldInfos)
				{
					//get action to set current field and store it in a list
					var fieldSetter = GetFieldAssigner<TestContainerClass, TestClass>(testClassFieldInfo);
					_fieldInitializers.Add(fieldSetter);
				}
			}
			//next lines will set all 
			foreach (var fieldInitializer in _fieldInitializers)
			{
				fieldInitializer(this,new TestClass());
			}
		}
		
		public static Action<T, I> GetFieldAssigner<T, I>(FieldInfo fieldInfo)
		{
			ParameterExpression targetExp =
			Expression.Parameter(typeof(T), "target");
			ParameterExpression valueExp =
			Expression.Parameter(typeof(I), "value");
			MemberExpression fieldExp = Expression.Field(targetExp, fieldInfo);
			BinaryExpression assignExp = Expression.Assign(fieldExp, valueExp);
			var setter = Expression.Lambda<Action<T, I>>(assignExp, targetExp, valueExp).Compile();
			return setter;
		}
	}
