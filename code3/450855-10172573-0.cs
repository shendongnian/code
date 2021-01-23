	SqlCommand com = new SqlCommand("SELECT id, nome, sigla FROM  pais WHERE (estado=@estado)", connection);
	com.Parameters.Add(new SqlParameter("estado", value)); 
            SqlDataAdapter cidadeTableAdapter = new SqlDataAdapter();
            cidadeTableAdapter.SelectCommand = this.com;
            DataSet set = new DataSet("return");
            cidadeTableAdapter.Fill(set);
            this.com.Connection.Close();
            return set;
