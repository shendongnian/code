            DataTable dt = new DataTable();
            dt.Columns.Add("type", typeof(string)); 
            dt.Rows.Add("Rock'n'Roll - guitar");
            GridView1.DataSource = dt;
            GridView1.DataBind();
