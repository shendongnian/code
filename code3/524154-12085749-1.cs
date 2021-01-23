     protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
           {
    	     gvBind(); //Bind gridview 
           }
         }
    public void gvBind()
    {
     	SqlDataAdapter dap = new SqlDataAdapter("select id, empName,empSalary from myTable", conn);
         DataSet ds = new DataSet();
         dap.Fill(ds);
    	 gvstatus.DataSource = ds.Tables[0];
         gvstatus.DataBind();
    }
----------
 
  
    protected void gvstatus_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Update the select row from girdview
            lblmsg.Text = "";
            try
            {
                GridViewRow row = (GridViewRow)gvstatus.Rows[e.RowIndex];
                Label lblid = (Label)gvstatus.Rows[e.RowIndex].FindControl("lblid");
                TextBox txtname = (TextBox)gvstatus.Rows[e.RowIndex].FindControl("txtEmpName");
                TextBox txtSalary = (TextBox)gvstatus.Rows[e.RowIndex].FindControl("txtempSalary");
                string empName = txtname.Text;
                string empSalary = txtSalary.Text;
                string lblID=lblid.Text;
                int result = UpdateQuery(empName, empSalary,lblID);
                if (result > 0)
                {
                    lblmsg.Text = "Record is updated successfully.";
                }
                gvstatus.EditIndex = -1;
                gvBind();
            }
            catch (Exception ae)
            {
                Response.Write(ae.Message);
            }
    
        }
