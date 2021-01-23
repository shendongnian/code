        public static T InstantiateType<T>(Type type)
		{
            if (type == null)
            {
                throw new ArgumentNullException("type", "Cannot instantiate null");
            }
            ConstructorInfo ci = type.GetConstructor(Type.EmptyTypes);
			if (ci == null)
			{
                throw new ArgumentException("Cannot instantiate type which has no empty constructor", type.Name);
			}
			return (T) ci.Invoke(new object[0]);
		}
