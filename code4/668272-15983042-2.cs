    protected void grdView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ListBox eventListbox = (ListBox)grdViewName.Rows[e.RowIndex].Cells[ZeroBasedCellNumberOfTheListBox].FindControl("eventListbox");
        // Retrieve the currently selected entity (row) from the database
        ParentEntity yourParentEntity = from entity in DataContext.ParentEntity where entity.ID == grdViewName.Rows[e.RowIndex].Cells[IndexOfYourEntitysID].Text;
        foreach (ListItem item in eventListbox.Items)
        {
            if (item.Selected)
            {
                EventType eventType = new EventType();
                eventType.ID = item.Value;
                eventType.Name = item.Text;
                yourParentEntity.EventTypes.Add(eventType);            }
        }
        DataContext.Commit();
}
