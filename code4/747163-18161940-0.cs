    DataTable dt_Category = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb1"].ToString()))
        {
            try
            {
                String cmdText = "SELECT CategoryName FROM Category";
                SqlCommand cmd = new SqlCommand(cmdText, cn);
                //cmd.Parameters.AddWithValue("@IsDeleted", "false");
                cn.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                myAdapter.Fill(dt_Category);
                cn.Close();
                GridView1.DataSource = dt_Category;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
    }
    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Add you data here
            DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList1");
            //Bind Data           
        }
    }
