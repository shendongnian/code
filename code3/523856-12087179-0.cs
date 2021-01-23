     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                string value0 = row[3].ToString();
                if (value0 == "0")
                {
                    e.Row.Cells[2].Text = "";
                    Button btn=new Button();
                    btn.Text="finish";
                    e.Row.Cells[2].Controls.Add(btn);
                }
            }
        }
     protected void Page_Load(object sender, EventArgs e)
        {
            gvBind();
        }
        public void gvBind()
        {
            SqlDataAdapter dap=new SqlDataAdapter("select * from myTable",con);
            DataSet ds = new System.Data.DataSet();
            dap.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
