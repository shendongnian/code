    public void Connect() {
          var strconnection = @"server='" + objfrmserver.cmbshowallsqlserver.SelectedValue + "';database = anfd; Integrated Security = SS=PI";
          var conn = new SqlConnection(strconnection);
          conn.Open();
          // etc...
    }
