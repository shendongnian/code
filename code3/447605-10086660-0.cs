	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlInclude(typeof(Ressource))]	
	[System.Web.Services.WebServiceBindingAttribute(Name = "WSSoap", Namespace = "http:/tempuri.org/Web/WS/WS.asmx")]
	public class RemoteManager : System.Web.Services.Protocols.SoapHttpClientProtocol
	{
		public RemoteManager() {
			this.Url = "http://localhost/web/WS/WS.asmx";
			if ((this.IsLocalFileSystemWebService(this.Url) == true))
			{
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			}
			else
			{
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http:/tempuri.org/Web/WS/WS.asmx/" +
			"GetRessource", RequestElementName = "GetRessource", RequestNamespace = "http:/tempuri.org/Web/WS/WS.asmx", ResponseElementName = "GetRessourceResponse", ResponseNamespace = "http:/tempuri.org/Web/WS/WS.asmx", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		[return: System.Xml.Serialization.XmlElementAttribute("GetRessourceResult")]
		public Ressource GetRessource(int ressId)
		{
			object[] results = this.Invoke("GetRessource", new object[] {
						ressId});
			return ((Ressource)(results[0]));
		}
		public new string Url
		{
			get
			{
				return base.Url;
			}
			set
			{
				if ((((this.IsLocalFileSystemWebService(base.Url) == true)
							&& (this.useDefaultCredentialsSetExplicitly == false))
							&& (this.IsLocalFileSystemWebService(value) == false)))
				{
					base.UseDefaultCredentials = false;
				}
				base.Url = value;
			}
		}
		private bool useDefaultCredentialsSetExplicitly;		
		public new bool UseDefaultCredentials
		{
			get
			{
				return base.UseDefaultCredentials;
			}
			set
			{
				base.UseDefaultCredentials = value;
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}				
	}
