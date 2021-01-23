        public static OleDbConnection GetConnection()
        {
            var myCon = new OleDbConnection();
            myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C\:... Database2.mdb";
            return myCon;
        }
        public static void Insert(string id, string name)
        {
            var con = GetConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Table1 (ID, Name)";
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void Insertbtn_Click(object sender, EventArgs e)
        {
            Insert(IDTxt.Text, NameTxt.Text);
        }
