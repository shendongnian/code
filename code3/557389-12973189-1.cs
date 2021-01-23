    private void SortRows(int columnIndex, ListSortDirection direction)
            {
                if ((_rowArray == null) || (!_rowArray.Any()))
                    return;
    
                dataGridView1.EndEdit();
                
                RemoveRowDefinitions();
        
                if (direction == ListSortDirection.Ascending)
                {
                    var dataType = dataGridView1.Columns[columnIndex].ValueType;
                    try
                    {
                        switch (dataType.Name.ToLower())
                        {
                            case "double":
                                _rowArray = _rowArray.OrderBy(r => Parse<double?>(r[columnIndex].ToString())).ToArray();
                                break;
                            case "int32":
                                _rowArray = _rowArray.OrderBy(r => Parse<int?>(r[columnIndex].ToString())).ToArray();
                                break;
                            case "datetime":
                                _rowArray = _rowArray.OrderBy(r => Parse<DateTime?>(r[columnIndex].ToString())).ToArray();
                                break;
                            default:
                                _rowArray = _rowArray.OrderBy(r => r[columnIndex].ToString()).ToArray();
                                break;
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Cannot sort on the data type '" + dataType.Name + "'", ex);
                    }              
                }
    
                if (direction == ListSortDirection.Descending)
                {
                    var dataType = dataGridView1.Columns[columnIndex].ValueType;
                    try
                    {
                        switch (dataType.Name.ToLower())
                        {
                            case "double":
                                _rowArray = _rowArray.OrderByDescending(r => Parse<double?>(r[columnIndex].ToString())).ToArray();
                                break;
                            case "int32":
                                _rowArray = _rowArray.OrderByDescending(r => Parse<int?>(r[columnIndex].ToString())).ToArray();
                                break;
                            case "datetime":
                                _rowArray = _rowArray.OrderByDescending(r => Parse<DateTime?>(r[columnIndex].ToString())).ToArray();
                                break;
                            default:
                                _rowArray = _rowArray.OrderByDescending(r => r[columnIndex].ToString()).ToArray();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Cannot sort on the data type '" + dataType.Name + "'", ex);
                    }                    
                }
        
                dataGridView1.Refresh();
                ApplyRowDefinitions();
                GC.Collect();
            }
