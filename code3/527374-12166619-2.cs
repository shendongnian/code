     protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
               gvBind();
            }
        }
        public void gvBind()
        {
            SqlDataAdapter dap = new SqlDataAdapter("SELECT id, [JobTitle], [JobDatePosted], [JobLink] FROM [jobpostings]", con);
            DataSet ds = new System.Data.DataSet();
            dap.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvBind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvBind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtlink = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtesetLink");
            Label lblid = (Label)GridView1.Rows[e.RowIndex].FindControl("lblid");
           
            int result = UpdateQuery(txtlink.Text, lblid.Text);
    
            if (result > 0)
            {
                //lblmsg.text = "Record updated";
                Response.Write("Record updated");
            }
            GridView1.EditIndex = -1;
            gvBind();
    
        }
        public int UpdateQuery(string setlink,string id)
        {
            SqlCommand cmd=new SqlCommand("update jobpostings set JobLink='"+setlink+"' where id='"+id+"'",con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            con.Close();
            return temp;
        }
