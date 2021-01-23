        struct Item
        {
            public int mid;
            public int value;
        }
        public int Update(string connectionstring)
        {
            int res = 0;
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
            using (cmd.Connection = new System.Data.SqlClient.SqlConnection(connectionstring))
            {
                cmd.CommandText = @"UPDATE [table] SET [value] = @value WHERE [mid] = @mid;";
                cmd.CommandType = CommandType.Text;
                System.Data.SqlClient.SqlParameter mid = cmd.Parameters.Add("@mid", SqlDbType.VarChar);
                System.Data.SqlClient.SqlParameter value = cmd.Parameters.Add("@value", SqlDbType.VarChar);
                try
                {
                    cmd.Connection.Open();
                    foreach (Item item in GetItems("pathttothefile"))
                    {
                        mid.Value = item.mid;
                        value.Value = item.value;
                        res += cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            return res;
        }
        IEnumerable<Item> GetItems(string path)
        {
            string[] line;
            foreach (var item in System.IO.File.ReadLines(path))
            {
                line = item.Split(',');
                yield return new Item() { mid = int.Parse(line[0]), value = int.Parse(line[1]) };
            }
        }
