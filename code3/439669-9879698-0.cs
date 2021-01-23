    public class User
    	{
    		private DateTime _lastChangeDate;
    		public Action Validate()
    		{
    			if (_lastChangeDate >= DateTime.Now.AddDays(-30))
    			{
    				return new Action(() => this.Login());
    			}
    			else
    			{
    				return new Action(() => this.ChangePassword());
    			}
    		}
    		private void Login()
    		{
    			Console.WriteLine("Login");
    		}
    		private void ChangePassword()
    		{
    			Console.WriteLine("Change Password");
    		}
    	}
