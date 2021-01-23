    string cnstr=@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Works.mdf;Integrated Security=True;User Instance=True;Asynchronous Processing=true";
    
    using(SqlConnection con = new SqlConnection(cnstr))
     {
      string sql=Insert Into Estudante (Codigo,Nome,Apelido) values(@Codigo,@Nome,@Apelido)";
      using(SqlCommand command= new SqlCommand(sql,con))
       {
         command.Parameters.Add("@Codigo",SqlDbType.Int).Value=txtID.Text;
         command.Parameters.Add("@Nome",SqlDbType.VarChar,30).Value=txtNome.Text;
         command.Parameters.Add("@Apelido",SqlDbType.VarChar,30).Value=txtapelido.Text;
         con.Open();
         cmd.ExecuteNonQuery();
         con.Close();
        }
     }
