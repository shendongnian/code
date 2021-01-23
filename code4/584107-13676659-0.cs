    /* Create your columns, bands etc manually or
    have it done automatically after loading the data.*/
    ...
    // Load the data from the database to your gridControl
    ...
    // Step one
    RepositoryItemImageEdit imageControl = new RepositoryItemImageEdit();
    // Step two
    gridControl.RepositoryItems.Add(imageControl);
    // Step three
    /* view is the View assigned to your grid control
    where your data and columns are being shown.*/
    // Assuming your database blob field is named `Image`
    view.Columns["Image"].ColumnEdit = imageControl;
