    void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
       if(e.Column.FieldName!="Value") return;
       GridView gv = sender as GridView;
       string editorName = (string)gv.GetRowCellValue(e.RowHandle, "EditorName");
       switch (fieldName) {
          case "Spin Edit":
             e.RepositoryItem = repositoryItemSpinEdit1;
             break;
          case "Combo Box":
             e.RepositoryItem = repositoryItemComboBox1;
             break;
          case "Check Edit":
             e.RepositoryItem = repositoryItemCheckEdit1;
             break;
          //...
       }           
    }
