    class FormViewModel
    {
        string viewName;
        ...
        public FormViewModel(ProductType type)
        {
            viewName = type.Name;
            ...
        }
    }
