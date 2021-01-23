	//4. System.Collections.Generic.List<T> for loop
	var customersArray = customers.ToArray();
	watch.Restart();
	int customersCount = customersArray.Length;
	for (int i = 0; i < customersCount; i++)
	{
		if (dianaCheck(customers[i]))
			break;
	}
	watch.Stop();
	Console.WriteLine("Diana was found in {0} ms with an array for loop.", watch.ElapsedMilliseconds);
