     [System.Web.Services.WebMethod()] 
     [System.Web.Script.Services.ScriptMethod()] 
     public static void updateLogoutTime(string username, string pcname, string module)
        {
          String connectionString = ConfigurationManager.ConnectionStrings["VSConfigConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE [Access]  set LogOutDate =  '" + DateTime.Today.ToString("dd/MM/yyyy") + "', LogOutTime =  '" + DateTime.Now.ToString("HH:mm:ss") + "' WHERE LoginID ='" + username + "' AND ModuleID = '" + module + "' AND comptname ='" + pcname + "' AND LogOutDate= ' '", connection);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
        }
