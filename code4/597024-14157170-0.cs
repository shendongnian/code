    List<object> _selecteditems = new List<object>();
    foreach (var item in lstBox1.SelectedItems)
    {
        _selecteditems.Add(item);
    }
    foreach (var item in _selecteditems)
    {
      DataRow dr = dtSelctedDest.NewRow();
      dr[0] = ((DataRowView)item).Row[0].ToString();
      dr[1] = ((DataRowView)item).Row[1].ToString();
      dtSelctedItem.Rows.Add(dr);
      dtAllItem.Rows.Remove(dtAllItem.Rows.Remove.Select(string.Format("ID='{0}'", ((DataRowView)item).Row[0].ToString()))[0]);
     }
     lstBox1.DataContext = dtAllItem;
     lstBox2.DataContext = dtSelctedItem;
