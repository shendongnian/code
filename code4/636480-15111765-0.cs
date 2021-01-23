	public class LoginModel
	{
		public string Username {get;set;}
		public string Password {get;set;}
	}
	
	public class LoginViewModel
	{
		public string Username {get;set;}
		public string Fullname {get;set;}
		public string LastLogin {get;set;}
	}
	
	public ActionResult Login(LoginModel model) 
	{
		/* do whatever you need */
		
		return new LoginViewModel { ... };
	}
