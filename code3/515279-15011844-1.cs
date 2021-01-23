    private void EmployeesGrid_OnCellMouseUp(object sender,DataGridViewCellMouseEventArgs e)
    {
         if (e.ColumnIndex == 0 && e.RowIndex > -1)
         {
            _gvEmployees.EndEdit();
         }
    }
