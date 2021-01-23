    string sql = "INSERT INTO spending VALUES (@date, @amount_spent, @spent_on)";
     using (var cn = new SqlConnection("..connection string.."))
     using (var cmd = new SqlCommand(sql, cn))
       {
    cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date_dateTimePicker.Value;
    command.Parameters.AddWithValue("@amount_spent",Convert.ToDecimal(amount_spent_textBox.Text));
            command.Parameters.AddWithValue("@spent_on", spent_on_textBox.Text);
            connect.Open();
