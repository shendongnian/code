    private void PopulateCheckBoxList( List<MyClass> myClassList )
    {
        foreach ( MyClass m in myClassList )
        {
            ListItem item = new ListItem( m.Name, m.Id.ToString() );
            item.Selected = m.IsActive;
            cbxlFeatures.Items.Add( item );
        }
    }
