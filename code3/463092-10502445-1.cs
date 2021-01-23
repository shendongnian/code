    if (isNew)
    {
        newRow.SetAdded(); //Add the Insert State back
        isNew = false;
    }
    SqlCommandBuilder build = new SqlCommandBuilder(adaptor);
    adaptor.InsertCommand = build.GetInsertCommand();
    adaptor.UpdateCommand = build.GetUpdateCommand();
    adaptor.Update(issueTable);
