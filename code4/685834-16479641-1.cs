    var newGrid = MakeNewDataGrid();
    newGrid.ItemsSource = myTable.AsDataView();
    var template = XamlReader.Parse(HeaderRowTemplate) as ControlTemplate;
    
    foreach (int index in myHeaderIndices)
                        {
                            var container = newGrid.ItemContainerGenerator.ContainerFromIndex(index);
                            var row = container as DataGridRow;
                            if (row != null)
                            {
                                row.Template = template;
                            }
                        }
