    public MyWindow(){
           myDataGrid.AutoGeneratingColumn += AutoGeneratingColumnHandler;
    }
    private void AutoGeneratingColumnHandler(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            var bindingPath = ((e.Column as DataGridBoundColumn).Binding as Binding).Path.Path;
            if (bindingPath == "MYPATH") {
                  var checkBoxColumn = new DataGridCheckBoxColumn();
                  checkBoxColumn.Binding = new Binding(bindingPath);
                  e.Column = checkBoxColumn;
            }
     }
