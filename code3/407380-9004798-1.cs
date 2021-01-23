    List<int> IndicesToRemove = new List<int>();
    DataTable table = new DataTable(); //Obviously, your table will already exist at this point
    foreach (DataRow row in table.Rows)
    {
       if (!(row["ClientID"].ToString().Contains("A-") && row["ClientID"].ToString().Contains("N6")))
          IndicesToRemove.Add(table.Rows.IndexOf(row));
    }
    IndicesToRemove.Sort();
    for (int i = IndicesToRemove.Count - 1; i >= 0; i--) table.Rows.RemoveAt(IndicesToRemove[i]);
