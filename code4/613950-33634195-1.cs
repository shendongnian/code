	private void this_Leave (object sender, EventArgs e)
	{
		// If this is an autocomplete combo-box, select the
		// item that was found by autocomplete.
		// This seems like something that ComboBox should be
		// doing automatically...I wonder why it doesn't?
		if (this.AutoCompleteMode != AutoCompleteMode.None)
		{
			// Determine which combo-box item matches the text.
			// Since IndexOf() is case-sensitive, do our own
			// search.
			int iIndex = -1;
			string strText = this.Text;
			ComboBox.ObjectCollection lstItems = this.Items;
			int iCount = lstItems.Count;
			for (int i = 0; i < iCount; ++i)
			{
				string strItem = lstItems[i].ToString();
				if (string.Compare (strText, strItem, true) == 0)
				{
					iIndex = i;
					break;
				}
			}
			// If there's a match, and this isn't already the
			// selected item, make it the selected item.
			//
			// Force a selection-change-committed event, since
			// the autocomplete was driven by the user.
			if (iIndex >= 0
			&& this.SelectedIndex != iIndex)
			{
				this.SelectedIndex = iIndex;
				OnSelectionChangeCommitted (EventArgs.Empty);
			}
		}
	}
