	protected static PayPalAPIInterface GetService()
	{
		return new PayPalAPIInterfaceClient(new BasicHttpBinding()
				{
					SendTimeout = new TimeSpan(0, 5, 0),
					MaxReceivedMessageSize = 200000,
					Security = new BasicHttpSecurity()
					{
						Mode = BasicHttpSecurityMode.Transport,
						Transport = new HttpTransportSecurity()
										{
											ClientCredentialType = HttpClientCredentialType.None,
											ProxyCredentialType = HttpProxyCredentialType.None,
										},
						Message = new BasicHttpMessageSecurity()
									{
										ClientCredentialType = BasicHttpMessageCredentialType.Certificate,
									}
					}
				},
				new EndpointAddress(@"https://api-3t.paypal.com/2.0/")
			).ChannelFactory.CreateChannel();
	}
