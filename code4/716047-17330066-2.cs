    DataTable dt = new DataTable();
    string _CS = "Server=" + server + ";Port=" + port + ";Database=" + database + ";Uid=" + uid + ";Password=" + password;
    using (MySqlConnection connection2 = new MySqlConnection(_CS))
    {
        connection2.Open();
        string query = @"SELECT DISTINCT * FROM childDatabase";
        using (MySqlCommand cmd = new MySqlCommand(query, connection2))
        {
            // cmd.ExecuteNonQuery(); There's no need to execute this. da.Fill() will 
            // execute your command.
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                da.Fill(dt);
        }
        // connection2.Close(); No need to close either. The using statement does that.
    }
    foreach (var st in dt.AsEnumerable())
    {
        if (st.Field<string>("name2").Contains(childSearch.Text))
        // or .Contains(yourComboBox.SelectedItem.ToString())
        {
            childSearchCombo.Items.Add(st.Field<string>("name2"));
            firstNameDisp.Text = st.Field<string>("your column name");
            ageDisp.Text = st.Field<string>(0); // or by index
            genderDisp.Text = st.Field<string>("column name or index");
            // Note that st.Field<T> also can be a decimal, a bool, an int etc..
         }
    }
