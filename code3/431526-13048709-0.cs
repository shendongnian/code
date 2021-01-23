    // Populate ListBox
    int intRecordCount = objDataSet.Tables[0].Rows.Count;
    for (int i = 0; i <= intRecordCount - 1; i++)
    {
        ListItem lstListItem = new ListItem();
        lstListItem.Text = objDataSet.Tables[0].Rows[i]["SN_Notes"];
        lstListItem.Value = objDataSet.Tables[0].Rows[i]["ID"];
        this.lstNote.Items.Add(lstListItem);
    }
