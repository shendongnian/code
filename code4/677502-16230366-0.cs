    bool found = false;
    while (reader.Read())
    {   
      if (txtuser.Text == (reader["Username"].ToString()) && txtpass.Text == (reader["Password"].ToString()))
      {
        //MessageBox.Show("loged in!");
        Home newhome = new Home();
        newhome.Show();              
        this.Hide();
        found = true;
        break;
      }
    }
    if (!found)
        MessageBox.Show("Incorrect credentian..!");
