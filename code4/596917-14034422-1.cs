	foreach (BehaviorExtensionElement bxe in behavior)
	{
		var createBeh = typeof(BehaviorExtensionElement).GetMethod(
			"CreateBehavior", BindingFlags.Instance | BindingFlags.NonPublic);
		IServiceBehavior b = (IServiceBehavior)createBeh.Invoke(bxe, new object[0]);
		Console.WriteLine("BEHAVIOR: {0}", b);
		host.Description.Behaviors.Add (b);
	}
