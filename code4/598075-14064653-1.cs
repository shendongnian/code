    	public class AuthenticationModel
    	{
    		[Required]
    		[Display(Name = "Username")]
    		public string UserName { get; set; }
    		[Required]
    		[DataType(DataType.Password)]
    		[Display(Name = "Password")]
    		public string Password { get; set; }
    		[Display(Name = "Remember Me?")]
    		public bool RememberMe { get; set; }
    	}
