    DataTable dt = new DataTable();
    using (SqlConnection cnn = new SqlConnection("your_conn_string"))
    {
       string str = "Select Col1, Col2,... From profile " +
                    "Where unm = @unm and university= @uni and " +
                    "..." +
                    "ybatch = @ybatch";
    
       SqlCommand cmd = new SqlCommand(str, cnn);
       cmd.Parameters.AddWithValue("@unm",funm_txt.Text);
       cmd.Parameters.AddWithValue("@uni",DDLuni.SelectedValue);
       ...
       cmd.Parameters.AddWithValue("@ybatch",DDLbtch.SelectedValue);
    
       
       using (SqlDataAdapter adapter = new SqlDataAdapter())
       {
         adapter.SelectCommand = cmd;
    
         cnn.Open();
         adapter.Fill(dt);
       }
    }
    
    DataList1.DataSource =dt;
    DataList1.DataBind();
