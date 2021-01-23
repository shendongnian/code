    var sql = "INSERT INTO table ('Name', 'Gender', 'ComputerType') VALUES (@Name, @Gender, @ComputerType)";
    using (OracleConnection c = new OracleConnection("{cstring}"))
    {
        c.Open();
        using (OracleCommand cmd = new OracleCommand(sql, c))
        {
            cmd.Parameters.AddWithValue("@Name", textbox1.Text);
            cmd.Parameters.AddWithValue("@Gender", /* not sure how [checkbox1] maps here */);
            cmd.Parameters.AddWithValue("@ComputerType", dropdownlist1.SelectedValue);
            
            cmd.ExecuteNonQuery();
        }
    }
