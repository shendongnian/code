        /// <summary>
        /// Invokes the specified method of the named service.
        /// </summary>
        /// <by>J.BETTAIEB</by>
        /// <typeparam name="T">The expected return type.</typeparam>
        /// <param name="serviceName">The name of the service to use.</param>
        /// <param name="methodName">The name of the method to call.</param>
        /// <param name="args">The arguments to the method.</param>
        /// <returns>The return value from the web service method.</returns>
        public T InvokeMethod<T>( string serviceName, string methodName, params object[] args )
        {
            // create an instance of the specified service
            // and invoke the method
            object obj = this.webServiceAssembly.CreateInstance(serviceName);
            Type type = obj.GetType();
            return (T)type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, args);
        }
