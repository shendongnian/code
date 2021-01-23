    private void lookUpCompanyPerson_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
    {
        RepositoryItemLookUpEdit props
        if (sender is LookUpEdit)
            props = (sender as LookUpEdit).Properties;
        else
            props = sender as RepositoryItemLookUpEdit;
        if (props != null && (e.Value is int))
        {
            object row = props.GetDataSourceRowByKeyValue(e.Value);
            if (row != null)
            {
                e.Value = String.Format("{0} {1}", (DataRowView)row["FirstName"], (DataRowView)row["LastName"]);
                e.Handled = true;
            }
        }
    }
