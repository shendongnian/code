        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (conn)
            {
                SqlCommand command;
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Insert_TraadTabel_AND_Beskeder";
                command.Parameters.Add("@TradNavn", SqlDbType.NVarChar).Value = txtTraadNavn.Text;
                command.Parameters.Add("@KategoriID", SqlDbType.Int).Value = int.Parse(Request.QueryString["id"]);
                command.Parameters.Add("@Besked", SqlDbType.NVarChar).Value = txtBesked.Text;
                command.Parameters.Add("@BrugerNavn", SqlDbType.NVarChar).Value = txtBrugerNavn.Text;
                command.ExecuteNonQuery();
            }
        }
