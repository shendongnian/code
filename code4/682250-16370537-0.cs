    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
    {
	if (CheckBoxList1.Items[i].Selected)
	{
             CheckBoxList1.Items.RemoveAt(i);
	}
    }	
