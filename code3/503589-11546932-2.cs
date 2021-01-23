    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("item_id", typeof(Int64)));
    dt.Columns.Add(new DataColumn("monster_class_id", typeof(int)));
    dt.Columns.Add(new DataColumn("zone_id", typeof(int)));
    dt.Columns.Add(new DataColumn("xpos", typeof(float)));
    dt.Columns.Add(new DataColumn("ypos", typeof(float)));
    dt.Columns.Add(new DataColumn("timestamp", typeof(DateTime)));
     
    for (int i = 0; i < MY_INSERT_SIZE; i++) {
        dt.Rows.Add(new object[] { item_id, monster_class_id, zone_id, xpos, ypos, DateTime.Now });
    }
     
    // Now we&#039;re going to do all the work with one connection!
    using (SqlConnection conn = new SqlConnection(my_connection_string)) {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("insert_item_drops_rev4", conn)) {
            cmd.CommandType = CommandType.StoredProcedure;
     
            // Adding a "structured" parameter allows you to insert tons of data with low overhead
            SqlParameter param = new SqlParameter("@mytable", SqlDbType.Structured);
            param.Value = dt;
            cmd.Parameters.Add(param);
            SqlDataReader dr = cmd.ExecuteReader()
            // TODO: Read back in the objects, now attached to their primary keys
        }
    }
