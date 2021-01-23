    protected void Page_Load(object sender, EventArgs e)
        {
            //Runs query to determine if returnValue is greater then 1 then redirects if true 
            SqlConnection sqlConnection1 = new SqlConnection("ConnectionString");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(UID) FROM Table WHERE (USER = @USER)";
            cmd.CommandType = CommandType.Text;
            SqlParameter UserID = new SqlParameter("@USER", Request.QueryString["usr"]);
            UserID.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(UserID);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            int returnValue;
            returnValue = Convert.ToInt32(cmd.ExecuteScalar());
            sqlConnection1.Close();
            if (returnValue > 0)
            {
                Response.Redirect("morethanone?usr=" + Request.QueryString["usr"]);
            }
        }
