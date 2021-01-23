    con2.Open();
    try {
      if (cmd.ExecuteNonQuery() > 0) {
        throw new Exception("More than zero rows affected");
      }
      con2.Close();
      MessageBox.Show("Thnaks");
    }
    catch (Exception ex) {
     MessageBox.Show(ex.Message);
     con.Close();
    }
