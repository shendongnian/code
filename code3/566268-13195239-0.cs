    [Serializable]
    public class MyExceptionHandling : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            // here you would perform the logging
        }
    }
