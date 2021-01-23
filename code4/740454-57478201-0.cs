    // Add columns from this source.
                    foreach (var column in newColumns)
                        if (column != null)
                        {
                            var dg = (DataGrid)column.GetType().GetProperty("DataGridOwner", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(column, null);
                            dg?.Columns.Clear();
                            dataGrid.Columns.Add(column);
                        }
