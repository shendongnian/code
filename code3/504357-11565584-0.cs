    // the overall viewModel:
    public class OverallViewModel : ViewModelBase
    {
        public ObservableCollection<ProductViewModel> Products { get; set; };
    }
    // the item viewmodel:
    public class ProductViewModel : ViewModelBase
    {
        public string ProductName { get; set; }
        public int CountOfSold { get; set; }
    }
