    	using WebMatrix.Data;
    	using WebMatrix.WebData;
    	using SimpleCrypto;
    	public class CustomAuthenticationProvider : ExtendedMembershipProvider
    	{
    		private string applicationName = "CustomAuthenticationProvider";
    		private string connectionString = "";
    		private int HashIterations = 10000;
    		private int SaltSize = 64;
    
    		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    		{
    			try
    			{
    				if (config["connectionStringName"] != null)
    					this.connectionString = ConfigurationManager.ConnectionStrings[config["connectionStringName"]].ConnectionString;
    			}
    			catch (Exception ex)
    			{
    				throw new Exception(String.Format("Connection string '{0}' was not found.", config["connectionStringName"]));
    			}
    			if (config["applicationName"] != null)
    				this.connectionString = ConfigurationManager.ConnectionStrings[config["applicationName"]].ConnectionString;
    
    			base.Initialize(name, config);
    		}
    
    		public override bool ConfirmAccount(string accountConfirmationToken)
    		{
    			return true;
    		}
    
    		public override bool ConfirmAccount(string userName, string accountConfirmationToken)
    		{
    			return true;
    		}
    
    		public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
    		{
    			throw new NotImplementedException();
    		}
    
    		public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
    		{
    			// Hash the password using our currently configured salt size and hash iterations
    			PBKDF2 crypto = new PBKDF2();
    			crypto.HashIterations = HashIterations;
    			crypto.SaltSize = SaltSize;
    			string hash = crypto.Compute(password);
    			string salt = crypto.Salt;
    
    			using (SqlConnection con = new SqlConnection(this.connectionString))
    			{
    				con.Open();
    				int userId = 0;
    				// Create the account in UserProfile
    				using (SqlCommand sqlCmd = new SqlCommand("INSERT INTO UserProfile (UserName) VALUES(@UserName); SELECT CAST(SCOPE_IDENTITY() AS INT);", con))
    				{
    					sqlCmd.Parameters.AddWithValue("UserName", userName);
    					object ouserId = sqlCmd.ExecuteScalar();
    					if (ouserId != null)
    						userId = (int)ouserId;
    				}
    				// Create the membership account and associate the password information
    				using (SqlCommand sqlCmd = new SqlCommand("INSERT INTO webpages_Membership (UserId, CreateDate, Password, PasswordSalt) VALUES(@UserId, GETDATE(), @Password, @PasswordSalt);", con))
    				{
    					sqlCmd.Parameters.AddWithValue("UserId", userId);
    					sqlCmd.Parameters.AddWithValue("Password", hash);
    					sqlCmd.Parameters.AddWithValue("PasswordSalt", salt);
    					sqlCmd.ExecuteScalar();
    				}
    				con.Close();
    			}
    			return "";
    		}
    
    		public override bool ChangePassword(string username, string oldPassword, string newPassword)
    		{
    			// Hash the password using our currently configured salt size and hash iterations
    			PBKDF2 crypto = new PBKDF2();
    			crypto.HashIterations = HashIterations;
    			crypto.SaltSize = SaltSize;
    			string oldHash = crypto.Compute(oldPassword);
    			string salt = crypto.Salt;
    			string newHash = crypto.Compute(oldPassword);
    
    			using (SqlConnection con = new SqlConnection(this.connectionString))
    			{
    				con.Open();
    				con.Close();
    			}
    			return true;
    		}
    
    		public override bool ValidateUser(string username, string password)
    		{
    			bool validCredentials = false;
    			bool rehashPasswordNeeded = false;
    			DataTable userTable = new DataTable();
    
    			// Grab the hashed password from the database
    			using (SqlConnection con = new SqlConnection(this.connectionString))
    			{
    				con.Open();
    				using (SqlCommand sqlCmd = new SqlCommand("SELECT m.Password, m.PasswordSalt FROM webpages_Membership m INNER JOIN UserProfile p ON p.UserId=m.UserId WHERE p.UserName=@UserName;", con))
    				{
    					sqlCmd.Parameters.AddWithValue("UserName", username);
    					using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
    					{
    						adapter.Fill(userTable);
    					}
    				}
    
    				con.Close();
    			}
    
    			// If a username match was found, check the hashed password against the cleartext one provided
    			if (userTable.Rows.Count > 0)
    			{
    				DataRow row = userTable.Rows[0];
    
    				// Hash the cleartext password using the salt and iterations provided in the database
    				PBKDF2 crypto = new PBKDF2();
    				string hashedPassword = row["Password"].ToString();
    				string dbHashedPassword = crypto.Compute(password, row["PasswordSalt"].ToString());
    
    				// Check if the hashes match
    				if (hashedPassword.Equals(dbHashedPassword))
    					validCredentials = true;
    
    				// Check if the salt size or hash iterations is different than the current configuration
    				if (crypto.SaltSize != this.SaltSize || crypto.HashIterations != this.HashIterations)
    					rehashPasswordNeeded = true;
    			}
    
    			if (rehashPasswordNeeded)
    			{
    				// rehash and update the password in the database to match the new requirements.
    				// todo: update database with new password
    			}
    			
    			return validCredentials;
    		}
    }
