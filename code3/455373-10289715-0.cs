    public class Eval<T, TResult> : Activity<TResult>
    {
        public string Expression { get; set; }
    
        [RequiredArgument]
        public InArgument<T> Value { get; set; }
    
        protected override Func<Activity> Implementation
        {
            get
            {
                if (string.IsNullOrEmpty(Expression))
                {
                    return base.Implementation;
                }
    
                return () => new Assign<TResult>
                {
                    Value = new InArgument<TResult>(new VisualBasicValue<TResult>(Expression)),
                    To = new ArgumentReference<TResult>("Result")
                };
            }
            set
            {
                throw new NotSupportedException();
            }
        }
    }
