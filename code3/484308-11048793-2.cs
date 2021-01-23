    StringBuilder line = new StringBuilder();
    bool first = true;
    foreach (object o in theDataRow.ItemArray) {
      string s = o.Tostring();
      if (s.Contains("\"") || s.Contains(",")) {
        s = "\"" + s.Replace("\"", "\"\"") + "\"";
      }
      if (first) {
        first = false;
      } else {
        line.Adppend(',');
      }
      line.Append(s);
    }
    String csv = line.ToString();
