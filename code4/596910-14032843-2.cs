	//3. System.Collections.Generic.List<T> foreach
	Func<Customer, bool> dianaCheck = c => c.Name == diana;
	watch.Restart();
	foreach(var c in customers)
	{
		if (dianaCheck(c))
			break;
	}
	watch.Stop();
	Console.WriteLine("Diana was found in {0} ms with System.Collections.Generic.List<T> foreach.", watch.ElapsedMilliseconds);
