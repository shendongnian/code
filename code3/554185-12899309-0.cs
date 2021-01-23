    public class WcfServiceClass
    {
        public void ProblemServiceMethod()
        {
            using (log4net.ThreadContext.Stacks["logThisMethod"].Push("ProblemServiceMethod"))
            {
                // can also add the correlationId to the logs using this method.
                // call business logic...
    
            }
        }
    }
