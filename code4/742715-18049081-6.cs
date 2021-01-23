    private static PrasanjaViewModel viewModel=null;
    /// <summary>
    /// A static ViewModel used by the views to bind against.
    /// </summary>
    /// <returns>The MainViewModel object.</returns>
    public static PrasanjaViewModel ViewModel
    {
        get
        {
            // Delay creation of the view model until necessary
            if (viewModel == null)
            {
                viewModel = PresanjaViewModel.GetPresanje();
            }
            return viewModel;
        }
    }
