    public class ActionAuditor : ITraceWriter
    {
        private const string TargetOperation = "ExecuteAsync";
        private const string TargetOpeartor = "ReflectedHttpActionDescriptor";
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            var rec = new TraceRecord(request, category, level);
            traceAction(rec);
            if (rec.Operation == TargetOperation && rec.Operator == TargetOpeartor)
            {
                if (rec.Kind == TraceKind.Begin)
                {
                    // log the input of the action
                }
                else
                {
                    // log the output of the action
                }
            }
        }
    }
