        public string UserGetField(int user_id, int field)
        {
            var columns = new string[] { "first_name", "last_name", "grade", "phone", "address", "item" };
            var list = new List<string>();
            string command = columns[field - 1];
            var sql = string.Format("select '{0}' from User where user_id = '{1}'", command, user_id);
            var conStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + @"\test.mdb"; //
            using (var conn = new OleDbConnection(conStr))
            {
                conn.Open();
                var cmd = new OleDbCommand(sql, conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(dr[command].ToString());
                }
            }
            return string.Join(",", list.ToArray());
        }
