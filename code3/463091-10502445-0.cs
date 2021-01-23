    newRow = issueTable.NewRow();
    newRow["ID"] = Id;
    issueTable.Rows.Add(newRow);
    txtName.DataBindings.Add("Text", issueTable, "Name");
    newRow.AcceptChanges(); //Remove the Insert State, to accept modifications
    isNew = true;
