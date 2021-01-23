    public class StaticMethodInvoker : DynamicObject
    {
        Type _containingType;
        
        public StaticMethodInvoker(Type containingType)
        {
            _containingType = containingType;
        }
        
        public override bool TryInvokeMember(
            InvokeMemberBinder binder, Object[] args, out Object result)
        {
            result = _containingType.InvokeMember
                binder.Name,
                BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public,
                null, null, args);
            return true;
        }
    }
