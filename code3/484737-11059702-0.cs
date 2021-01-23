	var interfaces = NetworkInterface.GetAllNetworkInterfaces(); 
	
	foreach(var @interface in interfaces)
	{
		var ipv4Properties = @interface.GetIPProperties().GetIPv4Properties();
		if (ipv4Properties != null)
			Console.WriteLine(ipv4Properties.Index);
	}
