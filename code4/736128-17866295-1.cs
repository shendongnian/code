     SqlCommand cmd = new SqlCommand(query, con);
     cmd.CommandType = CommandType.Text;
     SqlDataAdapter da = new SqlDataAdapter(cmd);
     DataSet ds = new DataSet();
     da.Fill(ds, "ss");
     dataGridView1.DataSource = ds.Tables["ss"];
      
