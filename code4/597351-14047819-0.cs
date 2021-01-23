         private void fill_grid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Your sql command ";
            cmd.Parameters.Add("@param", SqlDbType.VarChar).Value = your_control.Text;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.sqlConnection1;
            this.sqlConnection1.Open();
            
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            your_grid.DataSource = ds;
           
            this.sqlConnection1.Close();
            this.your_grid.DataBind();
        }
