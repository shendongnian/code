	public void SwitchToWindow(Expression<Func<IWebDriver, bool>> predicateExp)
	{
		var predicate = predicateExp.Compile();
		foreach (var handle in driver.WindowHandles)
		{
			driver.SwitchTo().Window(handle);
			if (predicate(driver))
			{
				return;
			}
		}
		throw new ArgumentException(string.Format("Unable to find window with condition: '{0}'", predicateExp.Body));
	}
	SwitchToWindow(driver => driver.Title == "Title of your new tab");
