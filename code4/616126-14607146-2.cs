    public static class Extensions
    {
        //invoke a method with the specified name and parameter list
        // and return a result of type T
        public static T Call<T>(this object subject, string methodName, params object[] args)
        {
            //get the method with the specified name and parameter list
            Type[] argTypes = args.Select(arg => arg.GetType()).ToArray();
            MethodInfo method = subject.GetType().GetMethod(methodName, argTypes);
            //check if the method exists
            if (method == null)
                return default(T); //or throw an exception
            //invoke the method and get the result
            object result = method.Invoke(subject, args);
            //check if something was returned
            if (result == null)
                return default(T); //or throw an exception
            //check if the result is of the expected type (or derives from it)
            if (result.GetType().Equals(typeof(T)) || result.GetType().IsSubclassOf(typeof(T)))
                return (T)result;
            else
                return default(T); //or throw an exception
        }
        //invoke a void method more conveniently
        public static void Call(this object subject, string methodName, params object[] args)
        {
            //invoke Call<object> method and ignore the result
            subject.Call<object>(methodName, args);
        }
    }
