     if (context.Request.QueryString["Name"] != null)
        {
            querySqlStr = "SELECT Photo from UserProfile where UserName= @username" ;
        }
        conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand(querySqlStr, conn);.
        command.Parameters.Add("@username",context.Request.QueryString["Name"]);
