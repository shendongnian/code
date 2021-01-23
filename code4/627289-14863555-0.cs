    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    [AttributeUsage(AttributeTargets.Assembly|AttributeTargets.Class|AttributeTargets.Method, AllowMultiple = true)]
    [Serializable]
    public class TraceAttribute : MethodInterceptionAspect
    {
    // Details skipped.
    }
