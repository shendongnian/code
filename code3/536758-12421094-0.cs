	using (ChannelFactory<IPartyController> factory = new ChannelFactory<IPartyController>("IPartyControllerEndpoint"))
	{
		var timeoutTimeSpan = new TimeSpan(0, 0, parsedParameters.TimeOut);
		factory.Endpoint.Binding.SendTimeout = timeoutTimeSpan;
		
		EndpointAddress address = new EndpointAddress(String.Format("net.tcp://{0}/ServiceInterface/PartyController.svc", parsedParameters.HostName));
		IPartyController proxy = factory.CreateChannel(address);
		if (proxy != null)
		{
			try
			{
				// TODO: potentially call something more complex
				partyProfile = proxy.GetLatestPartyProfile(context, parsedParameters.PartyId);
			}
			// etc.
