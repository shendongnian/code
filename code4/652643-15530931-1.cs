    void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (CustomerViewModel custVM in e.NewItems)
                        custVM.PropertyChanged += this.OnCustomerViewModelPropertyChanged;
    
                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (CustomerViewModel custVM in e.OldItems)
                        custVM.PropertyChanged -= this.OnCustomerViewModelPropertyChanged;
            }
