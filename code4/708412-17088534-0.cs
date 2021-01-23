    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["forumConnectionString2"].ToString());          //definição do comando sql
        conn.Open();
        //Cria uma objeto do tipo comando passando como parametro a string sql e a string de conexão
        //Adicionando o valor das textBox nos parametros do comando
        SqlCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.StoredProcedure;
        comm.CommandText = "SP_veruseraposlogin";
        comm.Parameters.AddWithValue("@nome", Page.User.Identity.Name);
        SqlDataReader rdr = comm.ExecuteReader();
        if (rdr.HasRows)
        {
            while (rdr.Read())
            {
                loginid = rdr["Id"].ToString();
            }
            Lblidlog.Text = loginid;
            conn.Close();
        }
