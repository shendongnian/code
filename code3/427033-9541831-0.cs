        private void LoadData()
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.Connection = new SqlConnection("Data Source=YourServer;Initial Catalog=YourDatabase;Integrated Security=True");
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "SELECT * FROM table";
            SqlDataAdapter _da = new SqlDataAdapter();
            DataTable _Table = new DataTable();
            if (_cmd.Connection.State != ConnectionState.Open)
            {
                _cmd.Connection.Open();
            }
            _da.SelectCommand = _cmd;
            _da.Fill(_Table);
            _cmd.Connection.Close();
        }
