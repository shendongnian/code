    protected void Page_Load(object sender, EventArgs e)
    {
            dt = new DataTable();
            DataColumn dc1 = new DataColumn("FIRST NAME");
            DataColumn dc2 = new DataColumn("LAST NAME");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            DataRow dr1 = dt.NewRow();
            GridView1.DataSource = dt;
            GridView1.DataBind();
    }
    DataTable dt;
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataRow dr1 = dt.NewRow();
        dr1[0] = TextBox1.Text;
        dr1[1] = TextBox2.Text;
        dt.Rows.Add(dr1); 
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
