    try {
      if (cmd.ExecuteNonQuery() > 1) {
        throw new Exception("More than one row affected");
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
