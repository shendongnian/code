    public static void AssignSource() // I'm guessing at the name here.
    {
        PrintViewModel.ViewFullRecipeGrouping = new List<ViewFullRecipe>();
        PrintViewModel.ViewFullRecipeGrouping.Add(new ViewFullRecipe());
        var datagrid = new DataGrid();
        datagrid.ItemsSource = PrintViewModel.ViewFullRecipeGrouping;
    }
