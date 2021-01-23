	Items.CollectionChanged += OnItemsCollectionChanged;
	private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
		if (e.NewItems != null && e.NewItems.Count != 0) {
			foreach (ItemViewModel  vm in e.NewItems)
				vm.PropertyChanged += OnDetailVmChanged;
		}
		if (e.OldItems != null && e.OldItems.Count != 0) {
			foreach (ItemViewModel  vm in e.OldItems) {
				vm.PropertyChanged -= OnDetailVmChanged;
			}
		}
	}
