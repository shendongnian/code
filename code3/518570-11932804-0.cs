    using PostSharp.Aspects;
    [Serializable]
    public sealed class ReadyOnExit : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
            var state = (FTPDataTransferState)args.Instance;
            state.Transfer(FTPDataTransferState.Ready);
        }
    }
