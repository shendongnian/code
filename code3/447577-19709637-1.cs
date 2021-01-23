	// Inspired from: http://stackoverflow.com/a/12179408/1529139
	public static void InvokeIfRequired(Control control, MethodInvoker action)
	{
		if (control.IsDisposed)
		{
			return;
		}
		if (control.InvokeRequired)
		{
			try
			{
				control.Invoke(action);
			}
			catch (ObjectDisposedException) { }
			catch (InvalidOperationException e)
			{
				// Intercept only invokation errors (a bit tricky)
				if (!e.Message.Contains("Invoke"))
				{
					throw e;
				}
			}
		}
		else
		{
			action();
		}
	}
