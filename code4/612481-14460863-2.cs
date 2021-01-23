    GridColumn hyperLinkColumn = gridView1.Columns["Hyperlink"];
    //...
    RepositoryItemHyperLinkEdit hyperLinkEdit = new RepositoryItemHyperLinkEdit();
    hyperLinkColumn.ColumnEdit = hyperLinkEdit; // this line associated hyperlink with column
    hyperLinkEdit.OpenLink += hyperLinkEdit_OpenLink;
    //...
    void hyperLinkEdit_OpenLink(object sender, OpenLinkEventArgs e) {
        MessageBox.Show("HyperLinkEdit clicked!");
    }
