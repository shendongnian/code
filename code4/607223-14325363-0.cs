	public class UserData{
		
		public static Domain.Entities.UserProfile GetUser(){
			string username;
			try{
				username = Membership.GetUser().ProviderUserKey.ToString();
			}catch(Exception e){
				//	just in case
				throw new AuthenticationException("The user isn't authenticated!");
			}
			
			var user = HttpContext.Current.Session[username] as Domain.Entities.UserProfile;
			if(user == null){
				user = //	get data from database
				HttpContext.Current.Session[username] = user;
			}
			return user;
		}
	}
