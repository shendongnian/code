    con2.Open();
    try {
      if (cmd.ExecuteNonQuery() > 1) {
        throw new Exception();
      }
      con2.Close();
      MessageBox.Show("Thnaks");
    }
    catch (Exception ex) {
     MessageBox.Show(ex.Message);
     con.Close();
    }
