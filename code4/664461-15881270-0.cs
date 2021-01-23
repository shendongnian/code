    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtSODate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            //--
            dtProductDet = new DataTable("dtProductDet");
            dtProductDet.Columns.Add("PID", typeof(int));
            dtProductDet.Columns.Add("PName", typeof(string));
            dtProductDet.Columns.Add("Quan", typeof(decimal));
            dtProductDet.Rows.Add(0,"",0);
            //--
            GridView1.DataSource = dtProductDet;
            GridView1.DataBind();
        }
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToUpper())
        {
            case "ADD":
                dtProductDet.Rows.Add(0, "", 0);
                break;
            case "DELETE":
                dtProductDet.Rows.RemoveAt(Convert.ToInt32(e.CommandArgument));
                break;
        }
        GridView1.DataBind();
    }
