    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    [AttributeUsage(AttributeTargets.Class)]
    public class RunOutOfProcessAttribute : MethodInterceptionAspect
    {
        protected static bool IsOutOfProcess;
    
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            ...
        }
    
        public override bool CompileTimeValidate(MethodBase method)
        {
            if (method.DeclaringType.GetInterface("IDisposable") == null)
                throw new InvalidAnnotationException("Class must implement IDisposable " + method.DeclaringType);
    
            if (!method.Attributes.HasFlag(MethodAttributes.Public) && //if method is not public
                !MethodMarkedWith(method,typeof(InitializerAttribute))) //method is not initialiser
                return false; //silently ignore.
    
            return true;
        }
    }
