    GetDataFromDB()
    {
	Dictionary<string,string> infor = (Dictionary<string,string>)Session["queryInfo"];
	
	try
    {
        using (MySqlConnection conn = new MySqlConnection(clsUser.connStr))
        {
            conn.Open();
            string strQuery = "select DISTINCT user_id,description,sap_system_password from sap_password_info where user_id is not null";
            if (infor["sid"] !="")
            {
                strQuery += " AND sid = '" + infor["sid"] + "'";
            }
            //... do like above for remaining if conditions
            MySqlCommand cmd = new MySqlCommand(strQuery, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            Session["userinfo"] = dt;
            Response.Redirect("~\\PasswordInformation_Details.aspx");
        }
    }
    catch (Exception ex)
    {
         throw;
    }
    }
