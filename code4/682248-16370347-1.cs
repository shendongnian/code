    int lastIndex =CheckBoxList1.Items.Count-1;
    for( int i=lastIndex , i>=0 , i--)
    {
        if (CheckBoxList1.GetItemCheckState(i) == CheckState.Checked)
        {
                 CheckBoxList1.Items.RemoveAt(i);
        }
    }
