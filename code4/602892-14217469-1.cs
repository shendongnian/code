    private void Sort(DataTable table) {
      List<MyStuff> list = new List<MyStuff>(table.Rows.Count);
      for (int i = 0; i < table.Rows.Count; i++) {
        string valueA = table.Rows[MyStuff.A_INDEX].ToString();
        int itemB = Convert.ToInt32(table.Rows[MyStuff.B_INDEX]);
        list.Add(new MyStuff() { ValueA = valueA, ItemB = itemB });
      }
      list.Sort();
      m_dataGrid.DataSource = list;
    }
