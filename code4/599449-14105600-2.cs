      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("Select * from tblQuiz", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt=new DataTable();
        da.Fill(dt);
       
        DropDownList1.DataTextField = "QUIZ_Name";
        DropDownList1.DataValueField = "QUIZ_ID"
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
