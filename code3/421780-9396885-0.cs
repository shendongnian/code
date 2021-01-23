	string selected = Convert.ToString(gridView1.GetFocusedRowCellValue("vVendor")); 
	foreach ( var item in cmbVendor.Items ) 
	{
		if (string.Compare(item.ToString(), selected, StringComparison.OrdinalIgnoreCase) == 0)
		{
			cmbVendor.SelectedItem = item; 
			break; 
		}
	}
