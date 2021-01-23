    public interface IEnabled
    {
        bool Enabled { get; }
    }
    [Serializable]
    public class ModularAttribute : OnMethodBoundaryAspect
    {
        public override bool CompileTimeValidate(System.Reflection.MethodBase method)
        {
            if(typeof(IEnabled).IsAssignableFrom(method.DeclaringType))
                return true;
            Message.Write(method, SeverityType.Error, "MYERR001", "Aspect can't be used on a class that doesn't implement IEnabled");
            return false;
        }
    
        public override void OnEntry(MethodExecutionArgs args)
        {
            var obj = (IEnabled) args.Instance; // this will always be a safe cast
            if(!obj.Enabled)
                args.FlowBehavior = FlowBehavior.Return;
        }
    }
