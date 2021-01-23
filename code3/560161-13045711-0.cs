      protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
    
    
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
    
     SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=dbname;Integrated Security=True");
    
                    SqlCommand cmd = new SqlCommand("select lastname from Profile_Master where firstname='" + e.Row.Cells[0].Text + "'", con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    System.Data.DataSet DS=new System.Data.DataSet();
                    adp.Fill(DS);
    
                    
    
                    Control Ctr = e.Row.FindControl("ddl");
    
                    DropDownList dd =  (DropDownList)  Ctr;
                    dd.DataSource = DS;
                    dd.DataTextField = "LastName";
                    dd.DataValueField = "LastName";
                    dd.DataBind();
    
    }
    
    }
