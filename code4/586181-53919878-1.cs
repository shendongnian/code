    List<string> toinsert = new List<string>();
    StringBuilder insertCmd = new StringBuilder("INSERT INTO tabblename (col1, col2, col3) VALUES ");
    foreach (var row in rows)
    {
          // the point here is to keep values quoted and avoid SQL injection
          var first = row.First.Replace("'", "''")
          var second = row.Second.Replace("'", "''")
          var third = row.Third.Replace("'", "''")
          toinsert.Add(string.Format("( '{0}', '{1}', '{2}' )", first, second, third));
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
