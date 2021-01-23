        int right = 0;
        public int rebuild_tree(int parent, int left)
        {
            // the right value of this node is the left value + 1
            right = left + 1;
            // get all children of this node
            command = conn.CreateCommand();
            command.CommandText = "SELECT cat_id FROM tbl_RefDataCategory_mst WHERE parent_id=@parent";
            command.Parameters.Add("parent", SqlDbType.Int).Value = parent;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int temp = Convert.ToInt32(reader["cat_id"]);
                    right = rebuild_tree(temp, right);
                }
                command = conn.CreateCommand();
                command.CommandText = "UPDATE tbl_RefDataCategory_mst SET lft=@l, rgt=@r WHERE cat_id=@p";
                command.Parameters.Add("l", SqlDbType.Int).Value = left;
                command.Parameters.Add("r", SqlDbType.Int).Value = right;
                command.Parameters.Add("p", SqlDbType.Int).Value = parent;
                command.ExecuteNonQuery();
            }
            return right + 1;
        }
