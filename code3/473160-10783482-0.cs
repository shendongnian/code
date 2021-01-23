	public interface IMyWrapper
	{
	    void ResponseRedirect(string url);
	}
	public class MyWrapper : IMyWrapper
	{
	    public void ResponseRedirect(string url)
	    {
	        HttpContext.Current.Response.Redirect(url);
	    }
	}
	builder.Register(c => new MyWrapper())
	    .As<IWrapper>()
	    .InstancePerLifetimeScope();
