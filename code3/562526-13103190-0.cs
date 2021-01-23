    [Serializable]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!application.running)
                throw new Exception(String.Format("Method {0} is not allowed to call when application is not running.", args.Method.Name));
        }
    }
