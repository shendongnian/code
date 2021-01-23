    bool found;
    while (reader.Read())
    {
        if (txtuser.Text == (reader["Username"].ToString()) && 
            txtpass.Text == (reader["Password"].ToString()))
        {
            found = true;
            break;
        }                
    }
    if (found)
    {
        MessageBox.Show("loged in!");
        Home newhome = new Home();
        newhome.Show();
        this.Hide();
    }
    else
    {
        MessageBox.Show("Incorrect credentian..!");
    }
