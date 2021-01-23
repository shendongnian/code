    try {
      if (cmd.ExecuteNonQuery() > 0) {
        throw new Exception("More than zero rows affected");
      }
      MessageBox.Show("Thanks");
    }
    catch (Exception ex) {
     MessageBox.Show(ex.Message);
    }
    finally {
      con.Close();
      con2.Close();
      cmd.Close();
    }
