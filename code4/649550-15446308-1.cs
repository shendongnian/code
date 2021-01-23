    User aUser = null;
    try {
                while (dbReader.Read())
                {
                    if (dbReader.HasRows)
                    {
                        MessageBox.Show("Login successful!");
                        aUser = new User();
                    }
                    else
                    {
                        MessageBox.Show("Login failed");
                    }
                }
            }
    catch (Exception e) {
                            MessageBox.Show(e.ToString());
                        }
    finally {
              return aUser;
    }
