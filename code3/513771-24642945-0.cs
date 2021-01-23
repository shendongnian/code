    var tableAList = _dbImplementation.SelectAll<TableA>().ToList();
    var bindingSource = new BindingSource();
    bindingSource.DataSource = typeof (TableA);
    foreach (var tableA in tableAList)
    {
        bindingSource.Add(tableA);
    }
    dataGridView.DataSource = bindingSource;
