	private object locker = new Object();
	public void Method(int a)
	{
		lock (locker)
		{
			this.BeginInvoke((MethodInvoker) (() => Method(a)));
		}
	}
