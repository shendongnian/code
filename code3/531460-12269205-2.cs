    public class CustomerSupplier : ViewModelBase
    {
        public Customer Customer { get; set; }
    
        private void HandleSupplierSelectPropertChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Selected")
            {
                var selectedSupplier = (SupplierSelect)sender;
                // ...
            }
        }
        private IEnumerable<SupplierSelect> suppliersSelect;
        public IEnumerable<SupplierSelect> SuppliersSelect 
        {
            get
            {
                return suppliersSelect;
            }
            set
            {
                if (suppliersSelect != value)
                {
                   if (suppliersSelect != null)
                   {
                       foreach (var item in suppliersSelect)
                           item.PropertyChanged -= HandleSupplierSelectPropertChanged;
                   }
                   suppliersSelect = value;
                   if (suppliersSelect != null)
                   {
                       foreach (var item in suppliersSelect)
                           item.PropertyChanged += HandleSupplierSelectPropertChanged;
                   }
                   this.NotifyPropertyChanged("SuppliersSelect");
                }
            }
        }
    }
