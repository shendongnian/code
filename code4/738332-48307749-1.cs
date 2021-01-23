    public class WebServiceClientFactory<T> : IWebServiceClientFactory<T> {
		public WebServiceClientFactory() {
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.DefaultConnectionLimit = 9999;
		}
		public T GetClient(Credentials cred) {
			ChannelFactory<T> channelFactory = new ChannelFactory<T>(GetBinding(), new EndpointAddress(cred.Url));
			channelFactory.Endpoint.Behaviors.Remove<System.ServiceModel.Description.ClientCredentials>();
			channelFactory.Endpoint.Behaviors.Add(new CustomCredentials());
			channelFactory.Endpoint.Behaviors.Add(new CustomP6DbInstanceBehavior(cred.DatabaseInstanceId));
			channelFactory.Credentials.UserName.UserName = cred.Username;
			channelFactory.Credentials.UserName.Password = cred.Password;
			return channelFactory.CreateChannel();
		}
		private Binding GetBinding() {
			var security = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
			security.IncludeTimestamp = false;
			var encoding = new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8);
			var transport = new HttpsTransportBindingElement {
				MaxReceivedMessageSize = 20000000 // 20 megs
			};
			return new CustomBinding(security, encoding, transport);
		}
	}
