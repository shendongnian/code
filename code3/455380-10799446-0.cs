    public class Evaluate<TIn, TOut> : NativeActivity<TOut>
    {
    	[RequiredArgument]
    	public InArgument<string> ExpressionText { get; set; }
    	
    	[RequiredArgument]
    	public InArgument<TIn> Value { get; set; }
    
    	protected override void Execute(NativeActivityContext context)
    	{
    		var result = new ExpressionEvaluator(ExpressionText.Get(context)).EvalWith(Value.Get(context));
    		Result.Set(context, result);
    	}
    
    	private class ExpressionEvaluator : Activity<TOut>
    	{
    		[RequiredArgument]
    		public InArgument<TIn> Value { get; set; }
    
    		public ExpressionEvaluator(string predicate)
    		{
    			VisualBasic.SetSettingsForImplementation(this, new VisualBasicSettings { ImportReferences =
    				{ new VisualBasicImportReference { Assembly = typeof(TIn).Assembly.GetName().Name, Import = typeof(TIn).Namespace } } });
    
    			Implementation = () => new Assign<TOut>
    			{
    				Value = new InArgument<TOut>(new VisualBasicValue<TOut>(predicate)),
    				To = new ArgumentReference<TOut>("Result")
    			};
    		}
    
    		public TOut EvalWith(TIn value)
    		{
    			return WorkflowInvoker.Invoke(this, new Dictionary<string, object> { { "Value", value } });
    		}
    	}
    }
