    public class MyLoggingCallHandler : ICallHandler
    {
        IMethodReturn ICallHandler.Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("Invoking " + input.MethodBase.Name);
            IMethodReturn result = getNext()(input, getNext);
            Console.WriteLine("Done Invoke");
            return result;
        }
        int ICallHandler.Order { get; set; }
    }
