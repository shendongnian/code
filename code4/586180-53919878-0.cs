    List<string> toinsert = new List<string>();
    StringBuilder insertCmd = new StringBuilder("INSERT INTO tabblename (col1, col2, col3) VALUES ");
    foreach (traverse your loop here)
    {
          toinsert.Add(string.Format("( '{0}', '{1}', '{2}' )", "Val1", "Val2", "Val3"));
    }
    if (toinsert.Count != 0)
    {
          insertCmd.Append(string.Join(",", toinsert));
          insertCmd.Append(";");
    }
    using (MySqlCommand myCmd = new MySqlCommand(insertCmd.ToString(), SQLconnectionObject))
    {
          myCmd.CommandType = CommandType.Text;
          myCmd.ExecuteNonQuery();
    }
