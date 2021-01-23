    namespace Test
    {
    [Serializable]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class RaisePropertyChangedAttribute : MethodInterceptionAspect
    {
        private string propertyName;
        /// <summary>
        /// Compiles the time validate.
        /// </summary>
        /// <param name="method">The method.</param>
        public override bool CompileTimeValidate(MethodBase method)
        {
            return IsPropertySetter(method) && !method.IsAbstract && IsVirtualProperty(method);
        }
        /// <summary>
        /// Method invoked at build time to initialize the instance fields of the current aspect. This method is invoked
        /// before any other build-time method.
        /// </summary>
        /// <param name="method">Method to which the current aspect is applied</param>
        /// <param name="aspectInfo">Reserved for future usage.</param>
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            base.CompileTimeInitialize(method, aspectInfo);
            propertyName = GetPropertyName(method);
        }
        /// <summary>
        /// Determines whether [is virtual property] [the specified method].
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>
        ///   <c>true</c> if [is virtual property] [the specified method]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsVirtualProperty(MethodBase method)
        {
            if (method.IsVirtual)
            {
                return true;
            }
            var getMethodName = method.Name.Replace("set_", "get_");
            var getMethod = method.DeclaringType.GetMethod(getMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return getMethod != null && getMethod.IsVirtual;
        }
        private static string GetPropertyName(MethodBase method)
        {
            return method.Name.Replace("set_", string.Empty);
        }
        /// <summary>
        /// Determines whether [is property setter] [the specified method].
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>
        /// <c>true</c> if [is property setter] [the specified method]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsPropertySetter(MethodBase method)
        {
            return method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Method invoked <i>instead</i> of the method to which the aspect has been applied.
        /// </summary>
        /// <param name="args">Advice arguments.</param>
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var arg = args as MethodInterceptionArgsImpl;
            if ((arg != null) && (arg.TypedBinding == null))
            {
                return;
            }
            // Note ViewModelBase is base class for ViewModel
            var target = args.Instance as ViewModelBase;
            args.Proceed();
            if (target != null)
            {
                target.OnPropertyChanged(propertyName);                    
            }
        }
    }
    }
