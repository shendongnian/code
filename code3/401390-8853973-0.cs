    public class GenericHelper
    {
        public static void DoSomethingGeneric(GenericInvokerParameters parameters)
        {
            var targetMethodInfo = typeof(GenericInvoker).GetMethod("DoSomethingGeneric");
            var genericTargetCall = targetMethodInfo.MakeGenericMethod(parameters.InvokeType);
            genericTargetCall.Invoke(new GenericInvoker(), new[] { parameters });
        }
    }
    public class GenericInvoker
    {
        public void DoSomethingGeneric<T>(GenericInvokerParameters parameters)
        {
            //Call your generic class / method e.g.
            SomeClass.SomeGenericMethod<T>(parameters.SomeValue);
        }
    }
    public class GenericInvokerParameters
    {
        public GenericInvokerParameters(Type typeToInvoke, string someValue)
        {
            SomeValue = someValue;
            InvokeType = typeToInvoke;
        }
        public string SomeValue { get; private set; }
        public Type InvokeType { get; private set; }
    }
