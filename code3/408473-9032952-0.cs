     string country ="";
    if(cmbo_country.SelectedItem != null)
    country = cmbo_country.SelectedItem.ToString();
        string state = "";
    if(cmbo_state.SelectedItem !=null)
    state = cmbo_state.SelectedItem.ToString();
        MySqlConnection connection = new MySqlConnection("server=192.168.1.100;User Id=mcubic;password=mcs@2011$;database=mcs;Persist Security Info=True");
        MySqlCommand command = new MySqlCommand("Insert into test (name1,option1,state,country) VALUES ('" + textBox1.Text + "','" + cmbo_Options.SelectedItem.ToString() + "','" + state + "','" + country + "')", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
