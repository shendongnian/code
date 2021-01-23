    using (SqlConnection cnn= new SqlConnection (strConectionString))
    using (SqlDataAdapter daObj = new SqlDataAdapter(StrSql, cnn))
        {
            daObj.SelectCommand.Parameters.Add("@n", SqlDbType.Int);
            daObj.SelectCommand.Parameters["@n"].Value = GetItemFromArray();
            cnn.Open();
            //fill data table
            daObj.Fill(dt);
            cnn.Close();
        }
