                foreach (var column in dataGrid.Columns)
                {
                    DataGridTemplateColumn dgtColumn = null;
                    DataGridBoundColumn dgbColumn = null;
 
                    dgbColumn = column as DataGridBoundColumn;
                    if (dgbColumn == null)
                    {
                        dgtColumn = column as DataGridTemplateColumn;
                        CheckBox checkbox = (CheckBox)dgtColumn.CellTemplate.LoadContent();
                    }
                 }
