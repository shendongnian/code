    try {
                while (dbReader.Read())
                {
                    if (dbReader.HasRows)
                    {
                        MessageBox.Show("Login successful!");
                        return aUser;
                    }
                    else
                    {
                        MessageBox.Show("Login failed");
                        return null;
                    }
                }
            }
    catch (Exception e) {
                            MessageBox.Show(e.ToString());
                        }
