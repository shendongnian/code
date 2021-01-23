    public static class ProductMappingExtensions
    {
        public static ProductFormModel ToViewModel(this ProductDto dto)
        {
            // Mapping code goes here
        }
    }
    // Usage:
    var viewModel = dto.ToViewModel();
