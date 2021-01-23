    public class NativeEval<T, TResult> : NativeActivity<TResult>
    {
        [RequiredArgument]
        public InArgument<string> ExpressionText { get; set; }
        [RequiredArgument]
        public InArgument<T> Value { get; set; }
    
        private Assign Assign { get; set; }
        private VisualBasicValue<TResult> Predicate { get; set; }
        private Variable<TResult> ResultVar { get; set; }
    
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
    
            Predicate = new VisualBasicValue<TResult>("ExpressionText.Length");
            ResultVar = new Variable<TResult>("ResultVar");
            Assign = new Assign { To = new OutArgument<TResult>(ResultVar), Value = new InArgument<TResult>(Predicate) };
    
            metadata.AddImplementationVariable(ResultVar);
            metadata.AddImplementationChild(Assign);
        }
    
        protected override void Execute(NativeActivityContext context)
        {
            // this line, commented or not, is the same!
            Predicate.ExpressionText = ExpressionText.Get(context);
            context.ScheduleActivity(Assign, new CompletionCallback(AssignComplete));
        }
    
        private void AssignComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            // the result will always be the ExpressionText.Length 
            Result.Set(context, ResultVar.Get(context));
        }
    }
