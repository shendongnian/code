    // Create view source
    this.cycleDataview = new CollectionViewSource();
    this.cycleDataview.Source = this.cycleRecords;
           
     // Set Item Source to data grid
     this.DataGridCycleData.ItemsSource = this.cycleDataview.View;
    // Generate Columns for datagrid
     var columns = this.cycleRecords.First().CyclePartCols.Select((x, i) => new {PreDescriptor =  x.PreDescriptor, Index = i }).ToArray();
    foreach (var column in columns)
    {
      Binding binding = new Binding(string.Format("CyclePartCols[{0}].PartValue", column.Index));
      Binding bindingColor = new Binding(string.Format("CyclePartCols[{0}].TextColor", column.Index));
      **bindingColor.Source = this.cycleRecords;** // Binding source is required to set
      DataGridTextColumn dgc = new DataGridTextColumn();
     
      txtblckCol.Text = column.PreDescriptor;
      dgc.Header = txtblckCol;
      dgc.Binding = binding;
      this.DataGridCycleData.Columns.Add(dgc);
      BindingOperations.SetBinding(dgc, DataGridTextColumn.ForegroundProperty, bindingColor);                
  }
