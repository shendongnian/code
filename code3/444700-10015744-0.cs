	class ExpressionBinder<T> : INotifyPropertyChanged
	{
		public Func<T> Getter;
		public Action<T> Setter;
		public event PropertyChangedEventHandler PropertyChanged;
		protected IList<string> WatchingProps;
		public T Value
		{
			get { return Getter.Invoke(); }
			set { Setter.Invoke(value); }
		}
		public ExpressionBinder(Func<T> getter, Action<T> setter)
		{
			WatchingProps = new List<string>();
			Getter = getter;
			Setter = setter;
		}
		public ExpressionBinder(Func<T> getter, Action<T> setter, ref PropertyChangedEventHandler listenToChanges, IList<string> propertyNames)
		{
			Getter = getter;
			Setter = setter;
			listenToChanges += SourcePropertyChanged;
			WatchingProps = propertyNames;
		}
		protected void SourcePropertyChanged(object obj, PropertyChangedEventArgs args)
		{
			if (PropertyChanged != null && WatchingProps.Contains(args.PropertyName))
			{
				PropertyChanged(this, args);
			}
		}
		protected PropertyInfo GetPropertyInfo<TSource, TValue>(Expression<Func<TSource, TValue>> propertyLambda)
		{
			Type type = typeof(TSource);
			var member = propertyLambda.Body as MemberExpression;
			if (member == null)
				throw new ArgumentException(string.Format(
					"Expression '{0}' refers to a method, not a property.",
					propertyLambda));
			var propInfo = member.Member as PropertyInfo;
			if (propInfo == null)
				throw new ArgumentException(string.Format(
					"Expression '{0}' refers to a field, not a property.",
					propertyLambda));
			if (type != propInfo.ReflectedType &&
				!type.IsSubclassOf(propInfo.ReflectedType))
				throw new ArgumentException(string.Format(
					"Expresion '{0}' refers to a property that is not from type {1}.",
					propertyLambda,
					type));
			return propInfo;
		}
	}
	class ComparisonBinder<TSource, TValue> : ExpressionBinder<bool> where TSource : INotifyPropertyChanged
	{
		private readonly TSource instance;
		private readonly TValue comparisonValue;
		private readonly PropertyInfo pInfo;
		public ComparisonBinder(TSource instance, Expression<Func<TSource, TValue>> property, TValue comparisonValue)
			: base(null, null)
		{
			pInfo = GetPropertyInfo(property);
			this.instance = instance;
			this.comparisonValue = comparisonValue;
			Getter = GetValue;
			Setter = SetValue;
			instance.PropertyChanged += SourcePropertyChanged;
			WatchingProps.Add(pInfo.Name);
		}
		private bool GetValue()
		{
			return comparisonValue.Equals(pInfo.GetValue(instance, null));
		}
		private void SetValue(bool value)
		{
			if (value)
			{
				pInfo.SetValue(instance, comparisonValue, null);
			}
		}
	}
