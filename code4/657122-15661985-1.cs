    if (reader.HasRows)
    {
        while (reader.Read())
        {
            txtID.Text = reader["ID"].ToString();
        }
    } MessageBox.Show("ID Already exist");         // <--- remove this here
    else (reader.HasRows !=null // need here pls.  // <--- remove this here
