    AssociatedComboItems ai = new AssociatedComboItems();
    List<Orderables> tempList = new List<Orderables>();
    foreach (var t in comboBox1.Items)
    {
        ai.ComboBoxItem = t.ToString();
        for (int i = 0; i < fpSpread1.ActiveSheet.RowCount; i++)
        {
            Orderables orderables = new Orderables();  // ← Instantiate here
            orderables.Display = fpSpread1.ActiveSheet.Cells[i, 1].Text;
            orderables.ShowInDSR = (bool)fpSpread1.ActiveSheet.Cells[i, 0].Value;
            orderables.DisplayOrder = i;
            tempList.Add(orderables);
        }
        ai.AssociatedItems = tempList;
        tempList.Clear();
        if(AssociatedItems == null)
        AssociatedItems = new List<AssociatedComboItems>();
        AssociatedItems.Add(ai);
