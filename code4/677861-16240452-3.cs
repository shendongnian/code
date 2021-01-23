    class ExceptionManager
    {
        private Stack<IExceptionManagerContext> contexts;
    
        public ExceptionManager()
        {
            contexts = new Stack<IExceptionManagerContext>();
            PushContext(new DefaultExceptionManagerContext());
        }
    
        public void PushContext(IExceptionManagerContext context)
        {
            contexts.Push(context);
        }
    
        public void PopContext()
        {
            contexts.Pop();
        }
    
        private IExceptionManagerContext CurrentContext
        {
            get { return contexts.Peek(); }
        }
    
        public void Handle(Exception ex)
        {
            if (CurrentContext.EnableLogging) 
            {
                Log(ex);
            }
            else
            {
                DoSomethingElseWith(ex);
            }
        }
    }
    
