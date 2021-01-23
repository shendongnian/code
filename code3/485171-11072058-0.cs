        public void FazerComando(string comando)
        {
            using (var conn = sql())
            {
                comandos = new SqlCommand(comando, conn);
                comandos.ExecuteNonQuery();
            }
        }
        public DataTable Execute(string comando)
        {
            using (var conn = sql())
            {
                SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(comando, conn);
                DataTable dtResult = new DataTable();
                SQLDataAdapter.Fill(dtResult);
                return dtResult;
            }
        }
