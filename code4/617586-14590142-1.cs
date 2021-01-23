    private void ComboBox_Changed(object sender, SelectionChangedEventArgs e) {
	if (((ComboBox)sender).IsLoaded) { // disregard SelectionChangedEvent fired on population from binding
		if (e.RemovedItems.Count != 0) {
			for (Visual visual = (Visual)sender; visual != null; visual = (Visual)VisualTreeHelper.GetParent(visual)) { // Traverse tree to find corred selected item
				if (visual is DataGridRow) {
					DataGridRow row = (DataGridRow)visual;
					m_BeginEditRow = new MyRowItem((MyRowItem)row.Item); // Copy constructor, otherwise passed by reference
					break;
				}
			}
			MyEnum newItem = (MyEnum)e.AddedItems[0];
			MyEnum oldItem = (MyEnum)e.RemovedItems[0];
			if (m_BeginEditRow.Combo1 == newItem) {
				m_BeginEditRow.Combo1 = oldItem;
			} else {
				m_BeginEditRow.Combo2 = oldItem;
			}
			DoStuff(m_BeginEditRow, false);
		}
	}
}
