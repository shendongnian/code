    public T Get<T>(int id)
        {
            var newTypeName = typeof(T).FullName + "Data";
            var newType = Type.GetType(newTypeName);
            var argTypes = new [] { newType };
            var method = GetType().GetMethod("Get");
            var typedMethod = method.MakeGenericMethod(argTypes);
            return (T) typedMethod.Invoke(this, new object[] { id });
        }
