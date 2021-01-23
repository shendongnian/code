    public class FaultContractInterceptor : IInterceptor
    {
    	public void Intercept(IInvocation invocation)
    	{
    		try
    		{
    			invocation.Proceed();
    		}
    		catch (MyException myException)
    		{
    			var faultAttributes = invocation.Method.GetCustomAttributes(typeof (FaultContractAttribute), inherit: true) as FaultContractAttribute[];
    
    			if (faultAttributes.Any(f => f.DetailType.FullName == typeof (MyException).FullName))
    			{
    				throw new FaultException<MyException>(myException, myException.Message);
    			}
    			else
    			{
    				throw;
    			}
    		}
    	}
    }
