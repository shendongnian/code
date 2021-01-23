    public static class FormsExt
    {
    	public static void UnwiseInvoke(this Control instance, Action toDo)
    	{
    		if(instance.InvokeRequired)
    		{
    			instance.Invoke(toDo);
    		}
    		else
    		{
    			toDo();
    		}
    	}
    }
