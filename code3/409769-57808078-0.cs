    var folv = new FastObjectListView()
    {
        AllColumns = new List<OLVColumn>()
        {
            new OLVColumn("Name", "Name")
            {
                IsVisible = true,
                ShowTextInHeader = true
            }
            // Add other columns here...
        },
        HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable,
        View = System.Windows.Forms.View.Details
    };
    folv.RebuildColumns();
    // ObjectListView is now ready!
