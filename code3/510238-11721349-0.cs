            bool encontrou = false;
            string sql = "SELECT area, login, senha FROM tbl_usuarios WHERE login = '" + login + "' AND senha = '" + senha + "'";
            command = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    string area = dataReader["area"].ToString();
                    Session.Add("area", area);
                    encontrou = true;
                }
            }
