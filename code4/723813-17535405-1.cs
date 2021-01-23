	public interface IView
	{
		IAsyncResult BeginInvoke(Delegate method);
		object Invoke(Delegate method);
	}
