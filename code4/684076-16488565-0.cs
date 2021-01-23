    public void SetContacts(IEnumerable<User> contactList, User reqUser)
    {
        BoundColumn reqColumn = new BoundColumn();
        reqColumn.HeaderText = "";
        dgExistingContacts.Columns.Add(reqColumn);
        dgExistingContacts.DataSource = contactList;
        dgExistingContacts.DataBind();
        foreach (DataGridItem row in dgExistingContacts.Items)
        {
            if (row.Cells[0].Text == reqUser.id.ToString())
                row.Cells[6].Text = "Requestor";
        }
    }
