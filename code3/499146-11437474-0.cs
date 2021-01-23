    foreach (Excel.Range cell in namedRange.Cells)
                {
                    if (String.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        string thisCellHasContent = cell.Value.ToString();
                        string thisCellAddress = cell.Address.ToString();
                    }
                } 
