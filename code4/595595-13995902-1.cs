    public partial class SearchField : UserControl
    {
        private SearchViewModel viewModel;
        public SearchField() 
        {
            this.viewModel = new SearchViewModel ();
            this.DataContext = this.viewModel;
        }
    }
