	public class ActionContext
	{
	    public Action Action;
	    public int Variable = 0;
	    public delegate void Foo(ref int i);
		
		public ActionContext(ActionContext.Foo action)
		{
			Action = () => action(ref this.Variable);    
		}
	}
	
	
	
	public void Test()
	{
	    // I don't want provide ActionContext through delegate(ActionContext)
	    ActionContext context = new ActionContext(
			(ref int variable) => variable = 10);
	
	    context.Action.Invoke();
	}
