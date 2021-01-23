    private void BindGrid()
    {
        GridView1.DataSource = GetDataTable();
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataRow dr;
        DataTable dt = GetDataTable();
        dr = dt.NewRow();
        dr[0] = TextBox1.Text;
        dr[1] = TextBox2.Text;
        dt.Rows.Add(dr);
        ViewState["CurrentData"] = dt;
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox1.Focus();
        //**updated**
        BindGrid();
    }
    protected DataTable GetDataTable()
    {
        DataTable dt;
        if (ViewState["CurrentData"] != null)
        {
            dt = (DataTable)ViewState["CurrentData"];
        }
        else
        {
            dt = new DataTable();
            dt.Columns.Add("First Name", typeof(String));
            dt.Columns.Add("Last Name", typeof(String));
            //**Update**/
            ViewState["CurrentData"] = dt;
        }
        return dt;
    }
