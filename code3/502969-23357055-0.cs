    httpSim.SimulateRequest(new Uri("http://www.test.com"));
    HttpContext.Current.Request.Browser = new HttpBrowserCapabilities
					                                      	{
					                                      		Capabilities = new Dictionary<string,string>
					                                      			{
					                                      				{"majorversion", "8"},
																		{"browser", "IE"},
																		{"isMobileDevice","false"}
					                                      			}
					                                      	};
