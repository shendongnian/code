    String CRLF = "\r\n";
    String sql = String.Format(
          "SELECT * FROM Table2" + CRLF+
          "WHERE @Blood_Group = {0}" + CRLF+
          "AND @District = {1} " + CRLF+
          "AND Club_Name = {2}", 
          SqlUtils.QuotedStr(tsblood.Text), 
          SqlUtils.QuotedStr(tsdist.Text),
          SqlUtils.QuotedStr(tscname.Text));
    SqlDataAdapter sda = new SqlDataAdapter(sql, Mycon1);
