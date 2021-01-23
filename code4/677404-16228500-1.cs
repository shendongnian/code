    public static void AssignSource() // I'm guessing at the name here.
    {
        var datagrid = new DataGrid();
        //ViewFullRecipeGrouping is not static so will throw the exception.
        datagrid.ItemsSource = PrintViewModel.ViewFullRecipeGrouping;
    }
