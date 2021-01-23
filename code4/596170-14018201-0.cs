    //...
    var repositoryItemTextEditReadOnly = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
    repositoryItemTextEditReadOnly.Name = "repositoryItemTextEditReadOnly";
    repositoryItemTextEditReadOnly.ReadOnly = true;
    //...
    void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
        if(e.RowHandle == 0)
            e.RepositoryItem = repositoryItemTextEditReadOnly;
    }
