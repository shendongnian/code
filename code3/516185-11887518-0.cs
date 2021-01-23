    public class GPUser
    {
		public readonly static string DataBase = Dynamics.Globals.IntercompanyId.Value;
		public readonly static string UserID = Dynamics.Globals.UserId.Value;
		public readonly static string Password = Dynamics.Globals.SqlPassword.Value;
		public readonly static string DataSource = Dynamics.Globals.SqlDataSourceName.Value;
		public readonly static string ApplicationName = string.Format("{0}{1}", App.ProductName, "(gp)");
	    public static SqlConnectionStringBuilder ConnectionString
	    {
		    get 
			{
				return new SqlConnectionStringBuilder
				{
					DataSource = DataSource,
					UserID = UserID,
					Password = Password,
					ApplicationName = ApplicationName,
					InitialCatalog = DataBase
				};
			}
		
	    }
		public readonly static short CompanyId = Dynamics.Globals.CompanyId.Value;
		public readonly static DateTime UserDate = Dynamics.Globals.UserDate.Value;
    }
