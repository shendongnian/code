    ...
    using(SqlCeDataReader reader = cmd.ExecuteReader())
    {
        if (reader.Read())
        {
            fname_txt.Text = reader.GetString(0);
            mname_txt.Text = reader.GetString(1); . . . 
            vacationno_txt.Text = reader.GetString(11);
        }
    }
    ...
