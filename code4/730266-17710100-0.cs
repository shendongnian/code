    int rowHandle = view.FocusedRowHandle;
    int groupRow = view.GetParentRowHandle(rowHandle);
    var childRows = GetChildRowsHandles(view, groupRow);
    if (childRows.Count > 0 && childRows.Last() == rowHandle)
    { 
        //selected row is the last datarow of its GroupRow
    }
    public List<int> GetChildRowsHandles(GridView view, int groupRowHandle)
        {
            List<int> childRows = new List<int>();  
            if (!view.IsGroupRow(groupRowHandle))
            {
                return childRows;
            }
                      
            int childCount = view.GetChildRowCount(groupRowHandle);
            for (int i = 0; i < childCount; i++)
            {
                int childHandle = view.GetChildRowHandle(groupRowHandle, i);
                if (view.IsDataRow(childHandle))
                {
                    if (!childRows.Contains(childHandle))
                        childRows.Add(childHandle);
                }
            }
            return childRows;
        }
