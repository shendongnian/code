    public class Evaluate<TIn, TOut> : NativeActivity<TOut>
    {
    	[RequiredArgument]
    	public InArgument<string> ExpressionText { get; set; }
    	
    	[RequiredArgument]
    	public InArgument<TIn> Value { get; set; }
    
    	protected override void Execute(NativeActivityContext context)
    	{
    		var result = new ExpressionEvaluator<TIn, TOut>(ExpressionText.Get(context)).EvalWith(Value.Get(context));
    		Result.Set(context, result);
    	}
    }
    
    public class ExpressionEvaluator<TIn, TOut> : Activity<TOut>
    {
    	[RequiredArgument]
    	public InArgument<TIn> Value { get; set; }
    
    	public ExpressionEvaluator(string predicate)
    	{
    		VisualBasic.SetSettingsForImplementation(this, VbSettings);
    
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
    	private static readonly VisualBasicSettings VbSettings;
	
    	static ExpressionEvaluator()
    	{
    		VbSettings = new VisualBasicSettings();
    		AddImports(typeof(TIn), VbSettings.ImportReferences);
    		AddImports(typeof(TOut), VbSettings.ImportReferences);
    	}
    	private static void AddImports(Type type, ISet<VisualBasicImportReference> imports)
    	{
    		if (type.IsPrimitive || type == typeof(void) || type.Namespace == "System")
    			return;
    		var wasAdded = imports.Add(new VisualBasicImportReference { Assembly = type.Assembly.GetName().Name, Import = type.Namespace });
    		if (!wasAdded)
    			return;
			
    		if (type.BaseType != null)
    			AddImports(type.BaseType, imports); 
			
    		foreach (var interfaceType in type.GetInterfaces())
				AddImports(interfaceType, imports);
    			
			foreach (var property in type.GetProperties())
				AddImports(property.PropertyType, imports);
    			
			foreach (var method in type.GetMethods())
    		{
    			AddImports(method.ReturnType, imports);
    				
				foreach (var parameter in method.GetParameters())
					AddImports(parameter.ParameterType, imports);
				if (method.IsGenericMethod)
				{
					foreach (var genericArgument in method.GetGenericArguments())
						AddImports(genericArgument, imports);
				}
    		}
			
    		if (type.IsGenericType)
			{
				foreach (var genericArgument in type.GetGenericArguments())
					AddImports(genericArgument, imports);
			}
    	}
    }
