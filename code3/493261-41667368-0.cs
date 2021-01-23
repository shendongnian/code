    private void ProductsDataGrid_UnloadingRow(object sender, DataGridRowEventArgs e)
    {
       MyObject obj = (MyObject)e.Row.Item; // get the deleted item to handle it
       // Rest of your code ...
       // For example : deleting the object from DB using entityframework
       
    }
