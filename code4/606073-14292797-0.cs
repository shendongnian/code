    private void SaveChanges()
    {
        try
        {
            if (sqlDataAdapter != null && dataTable.GetChanges() != null)
                sqlDataAdapter.Update(dataTable);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
