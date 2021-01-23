    protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from empreg where empid=@empid", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@empid", txtid.Text);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IDataReader dr = ds.Tables[0].CreateDataReader();
                    txtfname.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtlname.Text = ds.Tables[0].Rows[0][2].ToString();
                    RadioButtonList1.SelectedValue = ds.Tables[0].Rows[0][3].ToString();
                    txtdob.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtdoj.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtsal.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtadd.Text = ds.Tables[0].Rows[0][7].ToString();
                    DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0][8].ToString();
                    //checkbox1
                    string[] b = new string[50];
                    while (dr.Read())
                    {
                        b = dr["Dept"].ToString().Split(',');
    
                    }
    
                    for (int i = 0; i <= b.Length - 1; i++)
                    {
    
                        foreach (ListItem item in this.CheckBoxList1.Items)
                            if (item.Value == b[i])
                            {
                                item.Selected = true;
                                i++;
                            }
    
                    }
