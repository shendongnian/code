    public static DataTable CreateDT(string Setting, string Key, string Value)
    {
      DataTable dt = new DataTable(Setting);
      try {
        dt.Columns.Add("Key", typeof(String));   //<-- error here
        dt.Columns.Add("Value", typeof("String"));
        AddRow(ref dt, Key, Value);
      } catch (Exception err) {
        MessageBox.Show(err.Message);
        if (err.InnerException != null) {
          MessageBox.Show(err.InnerException.Message);
        }
      }
      return dt;
    }
