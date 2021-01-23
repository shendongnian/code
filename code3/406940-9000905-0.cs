	public class ConstantAccessor : IPropertyAccessor
	{
		#region IPropertyAccessor Members
		public IGetter GetGetter(Type theClass, string propertyName)
		{
			return new ConstantGetter();
		}
		public ISetter GetSetter(Type theClass, string propertyName)
		{
			return new NoopSetter();
		}
		public bool CanAccessThroughReflectionOptimizer
		{
			get { return false; }
		}
		#endregion
		[Serializable]
		private class ConstantGetter : IGetter
		{
			#region IGetter Members
			public object Get(object target)
			{
				return 0; // Always return constant value
			}
			public Type ReturnType
			{
				get { return typeof(object); }
			}
			public string PropertyName
			{
				get { return null; }
			}
			public MethodInfo Method
			{
				get { return null; }
			}
			public object GetForInsert(object owner, IDictionary mergeMap, ISessionImplementor session)
			{
				return null;
			}
			#endregion
		}
		[Serializable]
		private class NoopSetter : ISetter
		{
			#region ISetter Members
			public void Set(object target, object value)
			{
			}
			public string PropertyName
			{
				get { return null; }
			}
			public MethodInfo Method
			{
				get { return null; }
			}
			#endregion
		}
	}
