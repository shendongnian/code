    //do some database queries to return the appropriate value
    DataTable dt = new DataTable();
    private void Bind()
    {
        //set up the dt with all the required data from single or multiple tables
    }
    //Then in the page Load method, call the above Bind method
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
         {
              Bind();
         }
    }
    //then do something like the following 
    int idx = 0;    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //do some database queries to return the appropriate value, then do something like the following
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = dt.Rows[idx][0];
            e.Row.Cells[1].Text = dt.Rows[idx][1];
            //or maybe
            ((TextBox)e.Row.Cells[0].FindControl("textBox1")).Text = dt.Rows[idx][0];
            ((Label)e.Row.Cells[1].FindControl("label2")).Text = dt.Rows[idx][1];
            ((CheckBox)e.Row.Cells[1].FindControl("chkbx1")).Selected = (bool)dt.Rows[idx][2]; 
      
            idx++;
        }
    }
