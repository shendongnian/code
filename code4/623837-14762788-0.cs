    private Customer _selectedCustomer;
    public Customer SelectedCustomer
    {
        get {}
        set
        {
            if (_selectedCustomer != value)
            {
                Set("SelectedCustomer", ref _selectedCustomer, value);
                this.RaisePropertyChanged("SelectedCustomer");
                
                // Execute other changes to the VM based on this selection...
            }
        }
    }
