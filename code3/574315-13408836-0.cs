    var formDataGrids = new List<DataGridView>();
    if (usingTab1)
        formDataGrids.AddRange(tabPage1.Controls.OfType<DataGridView>());
    if (usingTab2)
        formDataGrids.AddRange(tabPage2.Controls.OfType<DataGridView>());
    if (usingTab3)
        formDataGrids.AddRange(tabPage3.Controls.OfType<DataGridView>());
    
    foreach(var thisGrid in formDataGrids)
        DoSomething(thisGrid);
