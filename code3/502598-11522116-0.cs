    protected void Button1_Click(object sender, EventArgs e) {
    List<string> checkedIDs = new List<string>();
    
     for (int i = 0; i < GridView1.Rows.Count; i++) {
        CheckBox chbox = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
        if (chbox.Checked == true)
        {
            checkedIDs.Add("'" + GridView1.Rows[i].Cells[1].Text + "'");
        }
    }
            string conn = ConfigurationManager.ConnectionStrings["Test_T3ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            string query = "select prod_name,price from products where prod_id in (" + string.Join(",", checkedIDs.ToArray()) + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
    }
