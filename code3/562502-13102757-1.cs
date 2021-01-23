    // Get all checked id's.
    var ids = chkGodownlst.Items.OfType<ListItem>()
        .Where(cBox => cBox.Selected)
        .Select(cBox => cBox.Value);
    
    // Now get all the rows that has a CountryID in the selected id's list.
    var a = dt.AsEnumerable().Where(r => 
        ids.Any(id => id == r.Field<int>("CountryID"))
    );
    // Create a new table.
    DataTable newTable = a.CopyToDataTable();
    // Now set the new table as DataSource to the GridView.
