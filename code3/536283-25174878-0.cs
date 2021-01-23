    //Server WCF
    public SomeService
    {
    	[OperationContract]
    	Collection<string> SomeMethod(string someString)
    	{
    		return new Collection<string>{"Some Item", "Another Item"};
    	}
    }
    //Client
    void button_Click(object sender, EventArgs e)
    {
    	var someService = new TypedServiceReference();
    	someService.BeginSomeMethod("Hello", this.someMethodEnded, someService);
    }
    //will be called once the server reply
    void someMethodEnded(IAsyncResult r)
    {
    	this.Invoke(new MethodInvoker(delegate//The callback is not in the GUI thread
    	{
    		var someService = (TypedServiceReference) r.AsyncState;//it is the last argument of the BeginSomeMethod() call
    		Collection<string> result = someService.EndSomeMethod(r);//Will raise server or network exception (if any)
    		this.Text = result.First();
    	}));
    }
