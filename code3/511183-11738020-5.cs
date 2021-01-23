    public sealed class RequiresCheckAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionEventArgs e)
        {
            // Do check here.
        }
    }
