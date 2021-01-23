    Public DataTable FillDataGrid(string orderID)
    {
           
    SqlCommand cmd = new SqlCommand("gridalldata", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@order_no", orderNo);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            return ds.Tables[0];  
    
    }
----------
    Datatable dt=FillDataGrid(txt_orderno.Text);
    DataGridVIew1.DataSource=dt;
