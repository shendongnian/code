    public sealed class RequiresCheckAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionEventArgs e)
        {
            doCheck();
        }
    }
