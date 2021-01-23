    public DataTable GetData()
    {
      int txt1 = Convert.ToInt32(textBox1.Text);
      int txt2 = Convert.ToInt32(textBox2.Text);
      DataTable dt = new DataTable();
      dt.Columns.Add("RollNo");
      dt.Columns.Add("TotalRolls");
      dt.Columns.Add("RollsFrom");
      dt.Columns.Add("RollsTo");
      for (int i = txt1; i < txt2 + 1; i++)
      {
          object[] row = { i, (txt2 - txt2), txt1, txt2};
          dt.Rows.Add(row);            
      }
      return dt;
    }
