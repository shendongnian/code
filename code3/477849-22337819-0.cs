	try
	{
		ServiceController sc = new ServiceController("Service Name", "Computer's IP Address");
		Console.WriteLine("The service status is currently set to {0}",
			sc.Status.ToString());
		if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
			(sc.Status.Equals(ServiceControllerStatus.StopPending)))
		{
			Console.WriteLine("Service is Stopped, Ending the application...");
			Console.Read();
			EndApplication();
		}
		else
		{
			Console.WriteLine("Service is Started...");
		}
	}
	catch (Exception)
	{
		Console.WriteLine("Error Occurred trying to access the Server service...");
		Console.Read();
		EndApplication();
	}
