	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	[ScriptService]
	public class JsonHTTPService : System.Web.Services.WebService
	{
		static JavaScriptSerializer JSON = new JavaScriptSerializer();
		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public dynamic update()
		{
			if (Session["user"] == null)
			{
				Session.Add("user", new User());
			}
			User user = (User)Session["user"];
			user.responseModel = new ResponseModel();
			if (user.updateListeners.Count > 0)
			{
				foreach (var updateMethod in user.updateListeners)
				{
					updateMethod.run();
				}
				return JSON.Serialize(user.responseModel);
			}
			return null;
		}
		[WebMethod(EnableSession = true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
		public void login(string email, string password)
		{
			if (Session["user"] == null)
			{
				return;
			}
			User user = (User)Session["user"];
			if (user.logged)
			{
				return;
			}
			if (user.Authenticate(email,password))
			{
				user.logged = true;
				user.updateListeners.Add(new LoginScreenRemover());
			}
		}
	}
