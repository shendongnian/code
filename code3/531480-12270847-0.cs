    /// <summary>
    /// Adds execution timing and automatic logging to the tagged method
    /// </summary>
    [Serializable]
    public class MethodTimeAttribute : OnMethodBoundaryAspect
    {
        private String MethodName { get; set; }
        private DateTime StartTime { get; set; }
        /// <summary>
        /// Method executed at build time. Initializes the aspect instance. After the execution
        /// of <see cref="CompileTimeInitialize"/>, the aspect is serialized as a managed 
        /// resource inside the transformed assembly, and deserialized at runtime.
        /// </summary>
        /// <param name="method">Method to which the current aspect instance 
        /// has been applied.</param>
        /// <param name="aspectInfo">Unused.</param>
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            MethodName = method.DeclaringType.FullName  "."  method.Name;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            StartTime = DateTime.Now;
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            Log.Debug(this, "Method {0} took {1} to execute", MethodName, DateTime.Now - StartTime);
        }
    }
