    protected void SetName(Label welcomeLabel)
    {
    	//this is the type of thing you'd probably wanna do in the Global.asax on session start
    	if (Session["userName"] == null || !Login()) return; //session variable is empty and the login attempt failed, give up
    	var usersName = Session["userName"].ToString();
    	welcomeLabel.Text = usersName;
    }
    protected bool Login()
    {
    	const string query = "SELECT Name FROM Users WHERE Password = @Password AND UserName = @UserName";
    	using (var conn = new SqlConnection(connectionString))
    	{
    		using (var comm = new SqlCommand(query, conn))
    		{
    			comm.CommandType = CommandType.Text;
    			comm.Parameters.Add(new SqlParameter("@Password", password)); //or get this from a control or wherever
    			comm.Parameters.Add(new SqlParameter("@UserName", userName)); //or get this from a control or wherever
    			conn.Open();
    			var name = (string)comm.ExecuteScalar();
    			if (!string.IsNullOrEmpty(name))
    			{
    				Session["userName"] = name;
    				return true;
    			}
    			//"Login information is wrong or user doesn't exist.
    			return false;
    		}
    	}
    }
