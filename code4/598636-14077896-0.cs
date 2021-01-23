    MySqlCommand comm = new MySqlCommand();
    comm.Connection = cn;
    comm.CommandType = CommandType.StoredProcedure;
    comm.CommandText = "AddMerchantProcessor";
    comm.Parameters.AddWithValue("m_id", m_id);
    comm.Parameters.AddWithValue("p_id", p_id);
    comm.Parameters.AddWithValue("d", d);
    cn.Open();
    comm.ExecuteNonQuery();
